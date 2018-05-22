using System.Collections.Generic;
using AudioHelm;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EmoListView : View, IEnhancedScrollerDelegate {
  public const string emoSpritePath = "Emos/";

  [SerializeField]
  private EnhancedScroller scroller;
  [SerializeField]
  private ScrollRect scrollRect;

  [SerializeField]
  private EmoTileView emoTilePrefab;
  [SerializeField]
  private GameObject sequencersRoot;
  [SerializeField]
  private GameObject sequencersPrefabs;

  private List<EmoTileData> emoDatas;

  [Inject]
  public AudioMixer audioMixer { get; set; }

  [Inject]
  public Dictionary<AudioMixerGroup, MusicManagerView> musicManagerViewDic { get; set; }

  public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex) {
    EnhancedScrollerCellView cellView = scroller.GetCellView(emoTilePrefab);
    cellView.SetData(emoDatas[dataIndex]);
    return cellView;
  }

  public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) {
    return 60f;
  }

  public int GetNumberOfCells(EnhancedScroller scroller) {
    return emoDatas.Count;
  }

  public void PopulateEmos(List<db_EmoData> datas) {
    emoDatas = new List<EmoTileData>();
    datas.ForEach(data => {
      emoDatas.Add(PopulateEmos(data));
    });

    CreateHelmSequencers();

    scroller.Delegate = this;
    scroller.ReloadData();

    scroller.Delegate = this;
    scroller.ReloadData();

    ContentSizeFitter sizeFitter = scrollRect.content.gameObject.AddComponent<ContentSizeFitter>();
    sizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
    sizeFitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
  }

  private EmoTileData PopulateEmos(db_EmoData data) {
    EmoTileData emoTileData = new EmoTileData(data);
    emoTileData.sprite = Resources.Load<Sprite>(emoSpritePath + data.Texture);
    if (emoTileData.soundType == SoundType.Sequencer) {
      emoTileData.audioMixerGroup = audioMixer.FindMatchingGroups(data.Patch) [0];
    }
    return emoTileData;
  }

  private void CreateHelmSequencers() {
    foreach (EmoTileData emo in emoDatas) {
      AudioSource audioSource = sequencersPrefabs.GetComponent<AudioSource>();
      audioSource.outputAudioMixerGroup = emo.audioMixerGroup;
      GameObject sequencer = sequencersRoot.InstantiateAsChild(sequencersPrefabs);
      emo.sequencer = sequencer.GetComponent<HelmSequencer>();
      if (emo.audioMixerGroup != null) {
        musicManagerViewDic.Add(emo.audioMixerGroup, sequencer.GetComponent<MusicManagerView>());
      }
    }
  }
}