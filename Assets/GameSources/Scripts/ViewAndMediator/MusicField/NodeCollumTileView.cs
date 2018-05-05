using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;

public class NodeCollumTileView : EnhancedScrollerCellView {
  [SerializeField]
  private GameObject nodeTile;
  public NodeCollumTileData nodeCollumTileData { get; private set; }
  private List<NodeTileView> nodeViews;

  public void PopulateNodeSlot(NodeCollumTileData data) {
    this.nodeCollumTileData = data;
    nodeViews = new List<NodeTileView>();
    for (int i = 0; i < data.emoDatas.Count; i++) {
      NodeTileView nodeView = gameObject.InstantiateAsChild(nodeTile).GetComponent<NodeTileView>();
      nodeView.Init(i);
      nodeViews.Add(nodeView);
    }
  }

  public override void SetData(EnhancedScrollerCellData data) {
    nodeCollumTileData = data as NodeCollumTileData;

    if (nodeViews == null) {
      PopulateNodeSlot(nodeCollumTileData);
    }
  }

  public void SetNode() {
    nodeViews.ForEach(node => {
      node.Reset();
    });
  }
}