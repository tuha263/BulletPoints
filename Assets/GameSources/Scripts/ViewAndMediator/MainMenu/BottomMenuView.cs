using AudioHelm;
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

  public void Init() {
    sliderValue.text = slider.value.ToString();
    slider.onValueChanged.AddListener(OnSliderValueChange);
    helmClock.pause = true;
    helmClock.bpm = slider.value;
    gameStateData.musicSpeed = slider.value;
  }

  private void OnSliderValueChange(float value) {
    sliderValue.text = value.ToString();
    helmClock.bpm = value;
    gameStateData.musicSpeed = value;
  }

  public void OnPlayClick(bool isPlaying) {}

}