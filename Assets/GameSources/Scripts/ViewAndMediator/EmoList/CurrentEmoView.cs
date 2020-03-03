using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEmoView : View {
  private const string DESCRIPTION_FORM = "Name: {0} \nStarting Note: {1}\nNote Length: {2}";
  [SerializeField]
  private Image icon;

  private EmoTileData data;

  public void Init(EmoTileData data) {
    this.data = data;
    icon.sprite = data.sprite;
  }
}