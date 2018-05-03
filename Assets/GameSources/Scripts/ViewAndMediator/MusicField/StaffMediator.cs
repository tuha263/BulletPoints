using strange.extensions.mediation.impl;

public class StaffMediator : Mediator {
  [Inject]
  public StaffView view { get; set; }

  public override void OnRegister() {
    view.PopulateLines();
  }
}