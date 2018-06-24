using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class ClefTileView : View {
  [SerializeField]
  private Image icon;
  public Button button;

  private db_ClefsData data;

  [Inject]
  public IGameStateData gameStateData { get; set; }
  public void Init(db_ClefsData data) {
    this.data = data;
    icon.sprite = ClefsDataManager.LoadSprite(data);
  }

  internal void OnClick() {
    gameStateData.currentClef = data;
  }
}