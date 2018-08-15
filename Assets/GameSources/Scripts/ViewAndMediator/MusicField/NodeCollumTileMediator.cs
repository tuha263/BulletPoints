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
  }

  private void Start()
  {
    view.OnChangeTempo();
  }

  private void OnPlayNote(IEvent payload) {
    int collumIndex = (int) payload.data;
    view.OnPlayNote(collumIndex);
  }

  private void OnChangeTempo(IEvent payload) {
    view.OnChangeTempo();
  }
}