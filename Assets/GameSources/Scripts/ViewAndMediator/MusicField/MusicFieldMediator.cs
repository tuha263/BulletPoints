using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MusicFieldMediator : EventMediator, IEnhancedScrollerDelegate {
  [Inject]
  public MusicFieldView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public MainGameContext mainGameContext { get; set; }
  private List<EnhancedScrollerCellData> cellDatas;

  public override void OnRegister() {
    mainGameContext.injectionBinder.Bind<MusicFieldMediator>().To(this);
    dispatcher.AddListener(GameEvent.OnInitStaff, Init);
    view.CreateMusicManager();
  }

  public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex) {
    EnhancedScrollerCellView cellView;
    if (cellDatas[dataIndex] is NodeCollumTileData) {
      cellView = scroller.GetCellView(view.nodeCollumViewPrefab);
    } else {
      cellView = scroller.GetCellView(view.melodyViewPrefab);
    }
    cellView.SetData(cellDatas[dataIndex]);

    return cellView;
  }

  public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) {
    return cellDatas[dataIndex].GetCellViewSize();
  }

  public int GetNumberOfCells(EnhancedScroller scroller) {
    return cellDatas.Count;
  }

  public void Init() {
    cellDatas = new List<EnhancedScrollerCellData>();
    cellDatas.Add(new MelodyTileData());
    for (int i = 0; i < gameStateData.musicLength; i++) {
      NodeCollumTileData nodeCollumData = new NodeCollumTileData();
      gameStateData.collumDatas.Add(nodeCollumData);
      cellDatas.Add(nodeCollumData);
    }

    view.enhancedScroller.Delegate = this;
    view.enhancedScroller.ReloadData();
  }
}