using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class MusicFieldView : View, IEnhancedScrollerDelegate {
  private const int INIT_COLLUM_AMOUNT = 100;

  [SerializeField]
  private GameObject root;

  [SerializeField]
  private NodeCollumTileView nodeCollumViewPrefab;
  [SerializeField]
  private MelodyTileView melodyViewPrefab;
  [SerializeField]
  private EnhancedScroller enhancedScroller;
  [SerializeField]
  private ScrollRect scrollRect;

  private List<EnhancedScrollerCellData> cellDatas;
  public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex) {
    EnhancedScrollerCellView cellView;
    if (cellDatas[dataIndex] is NodeCollumTileData) {
      cellView = scroller.GetCellView(nodeCollumViewPrefab) as NodeCollumTileView;
      (cellView as NodeCollumTileView).SetData(cellDatas[dataIndex] as NodeCollumTileData);
    } else {
      cellView = scroller.GetCellView(melodyViewPrefab) as MelodyTileView;
      (cellView as MelodyTileView).SetData(cellDatas[dataIndex] as MelodyTileData);
    }
    return cellView;
  }

  public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) {
    return 58.36f;
  }

  public int GetNumberOfCells(EnhancedScroller scroller) {
    return cellDatas.Count;
  }

  public void Init() {
    cellDatas = new List<EnhancedScrollerCellData>();
    cellDatas.Add(new MelodyTileData());
    for (int i = 0; i < INIT_COLLUM_AMOUNT; i++) {
      cellDatas.Add(new NodeCollumTileData());
    }

    enhancedScroller.Delegate = this;
    enhancedScroller.ReloadData();
  }

  public void Resize(bool keepPosition) {

  }
}