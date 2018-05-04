using System;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class CurrentEmoMediator : Mediator {
  [Inject]
  public CurrentEmoView view { get; set; }

  [Inject]
  public SelectEmoSignal selectEmoSignal { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public MainGameContext mainGameContext { get; set; }

  public override void OnRegister() {
    mainGameContext.injectionBinder.Bind<CurrentEmoMediator>().To(this);
  }

  public void OnSelectEmo(EmoTileData obj) {
    view.Init(obj);
  }
}