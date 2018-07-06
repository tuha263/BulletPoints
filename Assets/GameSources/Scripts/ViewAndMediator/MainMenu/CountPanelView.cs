using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CountPanelView : View {
  [SerializeField]
  private Text countText;

  public void SetText(string value) {
    countText.text = value;
  }
}