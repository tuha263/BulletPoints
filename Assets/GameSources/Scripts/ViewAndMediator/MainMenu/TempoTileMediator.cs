using System;
using strange.extensions.mediation.impl;

public class TempoTileMediator : EventMediator {
  [Inject]
  public TempoTileView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public ChangeTempoSignal changeTempoSignal { get; set; }

  public override void OnRegister() {
    view.button.onClick.AddListener(OnSelectTempo);
  }

  private void OnSelectTempo() {
    changeTempoSignal.Dispatch(view.tempo);
  }
}