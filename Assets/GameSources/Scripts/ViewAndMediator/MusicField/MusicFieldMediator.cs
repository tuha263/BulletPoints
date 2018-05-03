using strange.extensions.mediation.impl;

public class MusicFieldMediator : Mediator {
  [Inject]
  public MusicFieldView view { get; set; }

  public override void OnRegister() {
    view.Init();
  }
}