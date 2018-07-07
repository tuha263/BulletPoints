using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class TimeSigTileView : View {
  [SerializeField]
  private Image icon;
  public Button button;
  private db_TimeSigsData data;

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public SelectTimeSigSignal selectTimeSigSignal { get; set; }

  public void Init(db_TimeSigsData data) {
    this.data = data;
    icon.sprite = TimeSigsDataManager.LoadSprite(data);
  }

  internal void OnClick() {
    selectTimeSigSignal.Dispatch(data);
  }
}