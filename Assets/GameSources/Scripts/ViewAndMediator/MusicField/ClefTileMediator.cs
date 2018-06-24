using System;
using strange.extensions.mediation.impl;

public class ClefTileMediator : EventMediator {
  [Inject]
  public ClefTileView view { get; set; }

  public override void OnRegister() {
    view.button.onClick.AddListener(OnClick);
  }

  private void OnClick() {
    view.OnClick();
    dispatcher.Dispatch(GameEvent.OnChangeClef);
  }
}