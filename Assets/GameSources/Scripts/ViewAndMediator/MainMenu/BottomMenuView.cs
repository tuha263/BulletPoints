using System;
using System.Collections.Generic;
using AudioHelm;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuView : View {
  [SerializeField]
  public Button PlayButton;
  [SerializeField]
  public Button LoopButton;
  [SerializeField]
  private Slider slider;
  [SerializeField]
  private Text sliderValue;
  [Inject]
  public AudioHelmClock helmClock { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [SerializeField]
  private List<int> tempos;
  [SerializeField]
  private Button tempoButton;
  [SerializeField]
  private Text tempoText;
  [SerializeField]
  private GameObject tempListRoot;
  [SerializeField]
  private GameObject tempoTilePrefab;
  private bool isShowingTempSelection;

  public void Init() {
    sliderValue.text = slider.value.ToString();
    slider.onValueChanged.AddListener(OnSliderValueChange);
    helmClock.pause = true;
    helmClock.bpm = slider.value;
    gameStateData.musicSpeed = slider.value;
    tempoButton.onClick.AddListener(OnButtonTempoClick);
    InitTempo();
  }

  private void OnButtonTempoClick() {
    if (isShowingTempSelection) {
      HideTempoList();
    } else {
      ShowTempoList();
    }
  }

  private void OnSliderValueChange(float value) {
    sliderValue.text = value.ToString();
    helmClock.bpm = value;
    gameStateData.musicSpeed = value;
  }

  private void InitTempo() {
    tempos.ForEach(tempo => {
      TempoTileView tempoTile = tempListRoot.InstantiateAsChild(tempoTilePrefab).GetComponent<TempoTileView>();
      tempoTile.Init(tempo);
    });
    gameStateData.tempo = tempos[0];
    SetTempoText(tempos[0]);
    HideTempoList();
  }

  private const float tempoTweenTime = 0.2f;
  public void ShowTempoList() {
    tempoButton.interactable = false;
    tempListRoot.transform.DOScaleY(1, tempoTweenTime).OnComplete(() => {
      isShowingTempSelection = true;
    });
  }
  public void HideTempoList() {
    tempListRoot.transform.DOScaleY(0, tempoTweenTime).OnComplete(() => {
      tempoButton.interactable = true;
      isShowingTempSelection = false;
    });
  }

  public void SetTempoText(int tempo) {
    tempoText.text = BulletPointExtension.GetTempoString(tempo);
  }
}