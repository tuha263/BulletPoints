using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;

public class NodeCollumTileView : EnhancedScrollerCellView {
  [SerializeField]
  private GameObject nodeTile;

  [SerializeField]
  private int amountOfNode;

  private NodeCollumTileData data;

  public void PopulateNodeSlot() {
    for (int i = 0; i < amountOfNode; i++) {
      gameObject.InstantiateAsChild(nodeTile);
    }
  }

  public void SetData(NodeCollumTileData data) {
    this.data = data;
  }
}