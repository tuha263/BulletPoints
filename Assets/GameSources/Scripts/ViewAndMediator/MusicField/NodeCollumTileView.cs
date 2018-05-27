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
  private List<NodeTileView> noteViews;

  public void PopulateNodeSlot(NodeCollumTileData data) {
    this.nodeCollumTileData = data;
    noteViews = new List<NodeTileView>();
    for (int i = 0; i < data.emoDatas.Count; i++) {
      NodeTileView nodeView = notesRoot.InstantiateAsChild(nodeTile).GetComponent<NodeTileView>();
      nodeView.Init(i, this);
      noteViews.Add(nodeView);
    }
  }

  public override void SetData(EnhancedScrollerCellData data) {
    nodeCollumTileData = data as NodeCollumTileData;

    //Populate for the inital
    if (noteViews == null) {
      PopulateNodeSlot(nodeCollumTileData);
      return;
    }

    for (int i = 0; i < nodeCollumTileData.emoDatas.Count; i++) {
      noteViews[i].SetData(nodeCollumTileData.emoDatas[i]);
    }

  }

  public void SetNodeData(int index, EmoTileData emoTileData) {
    noteViews[index].SetData(emoTileData);
  }

  public void DoMoveNote(int startNoteIndex) {
    for (int i = 1; i < noteViews.Count; i++) {
      if (noteViews[i].emoTileData == null) {
        continue;
      }
      if (noteViews[i - 1].emoTileData == null) {
        if (i + 1 == noteViews.Count || noteViews[i + 1].emoTileData == null) {
          noteViews[i].MoveToNoteToCenter();
        }
        continue;
      }
      if (noteViews[i - 1].positionType != noteViews[i].positionType && noteViews[i - 1].positionType != NotePositionType.Center && noteViews[i].positionType != NotePositionType.Center) {
        continue;
      }

      if (noteViews[i - 1].positionType == NotePositionType.Center) {
        if (noteViews[i].positionType == NotePositionType.Center) {
          noteViews[i - 1].MoveNoteToLeft();
          noteViews[i].MoveNoteToRight();
        } else {
          MoveLeftRight(i, i - 1);
        }
      } else {
        MoveLeftRight(i - 1, i);
      }
    }
  }

  private void MoveLeftRight(int index1, int index2) {
    if (noteViews[index1].positionType == NotePositionType.Left) {
      noteViews[index2].MoveNoteToRight();
    } else {
      noteViews[index2].MoveNoteToLeft();
    }
  }
}