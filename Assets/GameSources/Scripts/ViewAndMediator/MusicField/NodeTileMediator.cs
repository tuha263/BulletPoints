using strange.extensions.mediation.impl;
using UnityEngine;

public class NodeTileMediator : Mediator {
  [Inject]
  public NodeTileView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public SetEmoSignal setEmoSignal { get; set; }

  public override void OnRegister() {
    view.AddOnclickListener(OnClick);
    view.nodeCollumTileView = transform.parent.parent.GetComponent<NodeCollumTileView>();
  }

  private void OnClick() {
    setEmoSignal.Dispatch(view.nodeCollumTileView, view.index);
    view.OnClick();
  }
}