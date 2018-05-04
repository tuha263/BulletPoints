using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class MusicFieldView : View, IEnhancedScrollerDelegate {
  private const int INIT_COLLUM_AMOUNT = 100;

  [SerializeField]
  private EnhancedScrollerCellView nodeCollumViewPrefab;
  [SerializeField]
  private EnhancedScrollerCellView melodyViewPrefab;
  [SerializeField]
  private EnhancedScroller enhancedScroller;

  [Inject]
  public IGameStateData gameStateData { get; set; }

  private List<EnhancedScrollerCellData> cellDatas;
  public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex) {
    EnhancedScrollerCellView cellView;
    if (cellDatas[dataIndex] is NodeCollumTileData) {
      cellView = scroller.GetCellView(nodeCollumViewPrefab);
    } else {
      cellView = scroller.GetCellView(melodyViewPrefab);
    }
    cellView.SetData(cellDatas[dataIndex]);

    return cellView;
  }

  public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) {
    if (cellDatas[dataIndex] is NodeCollumTileData) {
      return 58.36f;
    } else {
      return 110f;
    }
  }

  public int GetNumberOfCells(EnhancedScroller scroller) {
    return cellDatas.Count;
  }

  public void Init() {
    cellDatas = new List<EnhancedScrollerCellData>();
    cellDatas.Add(new MelodyTileData());
    for (int i = 0; i < INIT_COLLUM_AMOUNT; i++) {
      NodeCollumTileData nodeCollumData = new NodeCollumTileData();
      gameStateData.collumDatas.Add(nodeCollumData);
      cellDatas.Add(nodeCollumData);
    }

    enhancedScroller.Delegate = this;
    enhancedScroller.ReloadData();
  }

  public void Resize(bool keepPosition) {

  }
}