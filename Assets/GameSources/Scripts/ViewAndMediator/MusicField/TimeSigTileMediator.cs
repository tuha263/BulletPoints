using System;
using strange.extensions.mediation.impl;

public class TimeSigTileMediator : EventMediator {
  [Inject]
  public TimeSigTileView view { get; set; }

  

  public override void OnRegister() {
    view.button.onClick.AddListener(OnClick);
  }

  private void OnClick() {
    view.OnClick();
  }
}