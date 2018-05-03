using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class EmoTileView : View {
  [SerializeField]
  private Image icon;
  [SerializeField]
  private Button button;

  public void Init(Sprite sprite) {
    icon.sprite = sprite;
  }
}