using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEmoView : View {
  [SerializeField]
  private Image icon;

  [SerializeField]
  private Text description;

  private EmoTileData data;

  public void Init(EmoTileData data) {
    this.data = data;
    icon.sprite = data.sprite; 
  }
}