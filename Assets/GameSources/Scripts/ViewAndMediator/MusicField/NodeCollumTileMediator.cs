using strange.extensions.mediation.impl;

public class NodeCollumTileMediator : Mediator {
  [Inject]
  public NodeCollumTileView view { get; set; }

  public override void OnRegister() {
    view.PopulateNodeSlot();
  }
}