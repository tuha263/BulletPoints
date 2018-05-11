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

  public void Init() {
    sliderValue.text = slider.value.ToString();
    slider.onValueChanged.AddListener(OnSliderValueChange);
  }

  private void OnSliderValueChange(float value) {
    sliderValue.text = value.ToString();
  }

  public void OnPlayClick(bool isPlaying) {}

}