using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class NodeCollumTileMediator : EventMediator {
  [Inject]
  public NodeCollumTileView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void OnRegister() {
    dispatcher.AddListener(GameEvent.OnChangeTempo, OnChangeTempo);
    dispatcher.AddListener(GameEvent.OnPlayNote, OnPlayNote);
    view.OnChangeTempo(gameStateData.tempo);
  }

  private void OnPlayNote(IEvent payload) {
    int collumIndex = (int) payload.data;
    view.OnPlayNote(collumIndex);
  }

  private void OnChangeTempo(IEvent payload) {
    var tempo = (int) payload.data;
    view.OnChangeTempo(tempo);
  }
}