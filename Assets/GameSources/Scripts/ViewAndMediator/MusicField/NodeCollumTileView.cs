using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;

public class NodeCollumTileView : EnhancedScrollerCellView {
  [SerializeField]
  private GameObject nodeTile;
  [SerializeField]
  private GameObject notesRoot;
  public NodeCollumTileData nodeCollumTileData { get; private set; }
  private List<NodeTileView> nodeViews;

  public void PopulateNodeSlot(NodeCollumTileData data) {
    this.nodeCollumTileData = data;
    nodeViews = new List<NodeTileView>();
    for (int i = 0; i < data.emoDatas.Count; i++) {
      NodeTileView nodeView = notesRoot.InstantiateAsChild(nodeTile).GetComponent<NodeTileView>();
      nodeView.Init(i, this);
      nodeViews.Add(nodeView);
    }
  }

  public override void SetData(EnhancedScrollerCellData data) {
    nodeCollumTileData = data as NodeCollumTileData;

    //Populate for the inital
    if (nodeViews == null) {
      PopulateNodeSlot(nodeCollumTileData);
      return;
    }

    for (int i = 0; i < nodeCollumTileData.emoDatas.Count; i++) {
      nodeViews[i].SetData(nodeCollumTileData.emoDatas[i]);
    }
  }

  public void SetNodeData(int index, EmoTileData emoTileData) {
    nodeViews[index].SetData(emoTileData);
  }
}