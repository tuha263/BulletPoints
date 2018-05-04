using strange.extensions.mediation.impl;
using UnityEngine;

public class NodeTileMediator : Mediator {
  [Inject]
  public NodeTileView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void OnRegister() {
    view.AddOnclickListener(OnClick);
    view.nodeCollumTileView = transform.parent.GetComponent<NodeCollumTileView>();
  }

  private void OnClick() {
    if (gameStateData.currentEmo != null) {
      view.OnClick(gameStateData.currentEmo);
    } else {
      Debug.Log("Please select a emo");
    }
  }
}