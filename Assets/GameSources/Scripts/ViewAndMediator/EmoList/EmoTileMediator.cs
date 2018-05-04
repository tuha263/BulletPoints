using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class EmoTileMediator : Mediator {
  [Inject]
  public EmoTileView view { get; set; }

  [Inject]
  public SelectEmoSignal selecEmoSignal { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; } 

  public override void OnRegister() {
    view.SetOnClickListener(OnClick);
  }

  public void OnClick() {
    selecEmoSignal.Dispatch(view.GetData());
  }
}