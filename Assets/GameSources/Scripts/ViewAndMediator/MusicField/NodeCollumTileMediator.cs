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
    dispatcher.AddListener(GameEvent.OnLoadData, OnLoadData);
    view.initHeight();
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
  
  private void OnLoadData(IEvent payload)
  {
    view.OnLoadData();
  }

}