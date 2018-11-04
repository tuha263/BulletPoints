using System.Collections.Generic;
using System.Linq;
using AudioHelm;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EmoListView : View, IEnhancedScrollerDelegate
{
    private const string channel_param_post_fix = "_Channel";

    public const string emoSpritePath = "Emos/";

    [SerializeField] private EnhancedScroller scroller;
    [SerializeField] private ScrollRect scrollRect;

    [SerializeField] private EmoTileView emoTilePrefab;
    [SerializeField] private GameObject sequencersRoot;
    [SerializeField] private GameObject sequencersPrefabs;
    [SerializeField] private GameObject drumSequencersPrefabs;

    private List<EmoTileData> emoDatas;

    [Inject] public AudioMixer audioMixer { get; set; }

    [Inject] public Dictionary<AudioMixerGroup, MusicManagerView> musicManagerViewDic { get; set; }

    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        EnhancedScrollerCellView cellView = scroller.GetCellView(emoTilePrefab);
        cellView.SetData(emoDatas[dataIndex]);
        return cellView;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 60f;
    }

    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return emoDatas.Count;
    }

    public void PopulateEmos(List<db_EmoData> datas)
    {
        emoDatas = new List<EmoTileData>();
        datas.ForEach(data => { emoDatas.Add(PopulateEmos(data)); });

        CreateHelmSequencers();

        scroller.Delegate = this;
        scroller.ReloadData();

        scroller.Delegate = this;
        scroller.ReloadData();

        ContentSizeFitter sizeFitter = scrollRect.content.gameObject.AddComponent<ContentSizeFitter>();
        sizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
        sizeFitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
    }

    private EmoTileData PopulateEmos(db_EmoData data)
    {
        EmoTileData emoTileData = new EmoTileData(data);
        emoTileData.sprite = Resources.Load<Sprite>(emoSpritePath + data.Texture);
        if (emoTileData.soundType == SoundType.Sequencer)
        {
            emoTileData.audioMixerGroup = audioMixer.FindMatchingGroups(data.Patch)[0];
        }

        return emoTileData;
    }

    private void CreateHelmSequencers()
    {
        // emoDatas.ForEach(emo => {
        //   audioMixer.SetFloat(emo.data.Patch + channel_param_post_fix, emo.data.Channel);
        //   float a;
        //   audioMixer.GetFloat(emo.data.Patch + channel_param_post_fix, out a);
        //   Debug.Log(audioMixer.GetHashCode());
        //   Debug.Log(emo.data.Patch + channel_param_post_fix + ": " + a + " -> " + emo.data.Channel);
        // });
        //audioMixer.SetFloat("Bass_Bubbly_Volume", 20);

        //Create Drum Sequencer
        var drumSequencerView =
            sequencersRoot.InstantiateAsChild(drumSequencersPrefabs).GetComponent<DrumSequencerView>();
        musicManagerViewDic.Add(drumSequencerView.mixerGroup, drumSequencerView);

        emoDatas.ForEach(emo =>
        {
            switch (emo.soundType)
            {
                case SoundType.Sequencer:
                    AudioSource audioSource = sequencersPrefabs.GetComponent<AudioSource>();
                    if (emo.audioMixerGroup == null)
                    {
                        break;
                    }

                    audioSource.outputAudioMixerGroup = emo.audioMixerGroup;
                    GameObject sequencer = sequencersRoot.InstantiateAsChild(sequencersPrefabs);
                    emo.sequencer = sequencer.GetComponent<HelmSequencer>();
                    float channel = 0;
                    audioMixer.GetFloat(emo.data.Patch + channel_param_post_fix, out channel);

                    (emo.sequencer as HelmSequencer).channel = (int) channel;
                    if (emo.audioMixerGroup != null)
                    {
                        musicManagerViewDic.Add(emo.audioMixerGroup, sequencer.GetComponent<MusicManagerView>());
                    }

                    break;
                //Drum
                case SoundType.Drum:
                    emo.sequencer = drumSequencerView.sequencer;
                    emo.audioMixerGroup = drumSequencerView.mixerGroup;
                    break;
            }
        });
    }
}