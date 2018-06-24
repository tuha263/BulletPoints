using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class MelodyTileMediator : EventMediator {
  [Inject]
  public MelodyTileView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void OnRegister() {
    view.Init();
    dispatcher.AddListener(GameEvent.OnChangeClef, OnChangeClef);
    dispatcher.AddListener(GameEvent.OnChangeTimeSig, OnChangeTimeSig);
  }

  private void OnChangeTimeSig(IEvent payload) {
    
  }

  private void OnChangeClef(IEvent payload) {}
}