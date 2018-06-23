using System;
using strange.extensions.mediation.impl;

public class TempoTileMediator : EventMediator {
  [Inject]
  public TempoTileView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void OnRegister() {
    view.button.onClick.AddListener(OnSelectTempo);
  }

  private void OnSelectTempo() {
    gameStateData.tempo = view.tempo;
    dispatcher.Dispatch(GameEvent.OnChangeTempo, view.tempo);
  }
}