using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class NodeCollumTileView : EnhancedScrollerCellView {
  [SerializeField]
  private GameObject nodeTile;
  [SerializeField]
  private GameObject notesRoot;
  [SerializeField]
  private VerticalLayoutGroup lineVerticalLayout;
  [SerializeField]
  private GameObject measureBar;
  public NodeCollumTileData nodeCollumTileData { get; private set; }
  private List<NodeTileView> noteViews;

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public void PopulateNodeSlot(NodeCollumTileData data) {
    this.nodeCollumTileData = data;
    noteViews = new List<NodeTileView>();
    for (int i = 0; i < data.emoDatas.Count; i++) {
      NodeTileView nodeView = notesRoot.InstantiateAsChild(nodeTile).GetComponent<NodeTileView>();
      nodeView.Init(i, this);
      noteViews.Add(nodeView);
    }
  }

  public override void SetData(int dataIndex, EnhancedScrollerCellData data, IGameStateData gameStateData) {
    nodeCollumTileData = data as NodeCollumTileData;

    SetCollumLine(dataIndex, gameStateData);

    //Populate for the inital
    if (noteViews == null) {
      PopulateNodeSlot(nodeCollumTileData);
      return;
    }

    for (int i = 0; i < nodeCollumTileData.emoDatas.Count; i++) {
      noteViews[i].SetData(nodeCollumTileData.emoDatas[i]);
    }

    OnChangeTempo();
  }

  private void SetCollumLine(int dataIndex, IGameStateData gameStateData) {
    if (dataIndex % gameStateData.musicLength == 0) {
      measureBar.SetActive(true);
      lineVerticalLayout.gameObject.SetActive(false);
    } else {
      measureBar.SetActive(false);
      lineVerticalLayout.gameObject.SetActive(true);
      if (gameStateData.beatLength.Contains(dataIndex % gameStateData.musicLength)) {
        lineVerticalLayout.spacing = 0;
      } else {
        lineVerticalLayout.spacing = 10;
      }
    }
  }

  public override void RefreshCellView() {
    SetCollumLine(dataIndex, gameStateData);
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

  public void OnChangeTempo() {
    noteViews.ForEach(note => note.SetSetable());
  }

  public void OnPlayNote(int collumIdnex) {
    if (dataIndex - 1 != collumIdnex) {
      return;
    }

    noteViews.ForEach(noteView => noteView.OnPlay());
  }

  public void OnLoadData()
  {
    // the signature
    if (dataIndex == 0)
    {
      return;
    }
    
    for (int index = 0; index < gameStateData.collumDatas[dataIndex - 1].emoDatas.Count; index++)
    {
      var emoData = gameStateData.collumDatas[dataIndex - 1].emoDatas[index];
      SetNodeData(index, emoData);
    }
  }
}