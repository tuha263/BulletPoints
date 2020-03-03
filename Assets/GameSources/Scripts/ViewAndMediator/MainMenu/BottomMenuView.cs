using System.Collections.Generic;
using AudioHelm;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuView : View
{
    [SerializeField] public Button playButton;
    [SerializeField] public Button loopButton;
    [SerializeField] private Button tempoButton;
    [SerializeField] public Button saveButton;
    [SerializeField] public Button loadButton;

    [SerializeField] private Slider slider;
    [Inject] public AudioHelmClock helmClock { get; set; }

    [Inject] public IGameStateData gameStateData { get; set; }

    [SerializeField] private List<int> tempos;
    [SerializeField] private Text tempoText;
    [SerializeField] private GameObject tempListRoot;
    [SerializeField] private GameObject tempoTilePrefab;
    
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite stopSprite;
    [SerializeField] private Sprite loopSprite;
    [SerializeField] private Sprite noLoopSprite;
    
    [SerializeField] private Image playImage;
    [SerializeField] private Image loopImage;


    [Inject] public ChangeTempoSignal changeTempoSignal { get; set; }
    private bool isShowingTempSelection;
    private List<TempoTileView> tempoViews;

    public void Init()
    {
        slider.onValueChanged.AddListener(OnSliderValueChange);
        helmClock.pause = true;
        helmClock.bpm = slider.value;
        gameStateData.musicSpeed = slider.value;
        tempoButton.onClick.AddListener(OnButtonTempoClick);
        InitTempo();
    }

    private void OnButtonTempoClick()
    {
        if (isShowingTempSelection)
        {
            HideTempoList();
        }
        else
        {
            ShowTempoList();
        }
    }

    private void OnSliderValueChange(float value)
    {
        helmClock.bpm = value;
        gameStateData.musicSpeed = value;
    }

    private void InitTempo()
    {
        if (tempoViews == null)
        {
            tempoViews = new List<TempoTileView>();
        }

        for (int i = 0; i < tempos.Count; i++)
        {
            if (i >= tempoViews.Count)
            {
                TempoTileView tempoTile =
                    tempListRoot.InstantiateAsChild(tempoTilePrefab).GetComponent<TempoTileView>();
                tempoTile.Init(tempos[i]);
                tempoViews.Add(tempoTile);
                continue;
            }

            tempoViews[i].gameObject.SetActive(true);
            tempoViews[i].Init(tempos[i]);
        }

        for (int i = tempos.Count; i < tempoViews.Count; i++)
        {
            tempoViews[i].gameObject.SetActive(false);
        }

        gameStateData.tempo = tempos[0];
        SetTempoText(tempos[0]);
        HideTempoList();
    }

    private const float tempoTweenTime = 0.2f;

    public void ShowTempoList()
    {
        tempoButton.interactable = false;
        tempListRoot.transform.DOScaleY(1, tempoTweenTime).OnComplete(() => { isShowingTempSelection = true; });
    }

    public void HideTempoList()
    {
        tempListRoot.transform.DOScaleY(0, tempoTweenTime).OnComplete(() =>
        {
            tempoButton.interactable = true;
            isShowingTempSelection = false;
        });
    }

    public void SetTempoText(int tempo)
    {
        tempoText.text = BulletPointExtension.GetTempoString(tempo);
    }

    public void OnChangeTimeSig()
    {
        tempos = gameStateData.divisionList;
        InitTempo();
    }

    public void Play(bool play)
    {
        playImage.sprite = play ? stopSprite : playSprite;
    }

    public void Loop(bool loop)
    {
        loopImage.sprite = loop ? noLoopSprite : loopSprite;
    }
}