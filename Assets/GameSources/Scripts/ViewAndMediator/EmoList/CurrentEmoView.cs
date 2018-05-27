using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEmoView : View {
  private const string DESCRIPTION_FORM = "Name: {0} \nStarting Note: {1}";
  [SerializeField]
  private Image icon;

  [SerializeField]
  private Text description;

  private EmoTileData data;

  public void Init(EmoTileData data) {
    this.data = data;
    icon.sprite = data.sprite;
    description.text = string.Format(DESCRIPTION_FORM, data.data.Patch, data.data.Note);
  }
}