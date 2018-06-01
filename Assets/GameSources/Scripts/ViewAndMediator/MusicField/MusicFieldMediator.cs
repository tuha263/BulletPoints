using System;
using System.Collections.Generic;
using DG.Tweening;
using EnhancedUI.EnhancedScroller;
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
    mainGameContext.injectionBinder.Bind<MusicFieldMediator>().To(this).ToSingleton();
    dispatcher.AddListener(GameEvent.OnInitStaff, Init);
    view.enhancedScroller.ScrollRect.onValueChanged.AddListener(OnScroll);
    view.musicBar.gameObject.SetActive(false);
  }

  private void OnScroll(Vector2 position) {
    if (gameStateData.isPlaying) {
      return;
    }
    float collumSize = new NodeCollumTileData().GetCellViewSize();
    if (position.x >= 1) {
      for (int i = 0; i < gameStateData.musicLength; i++) {
        AddNewNodeCollum();
        view.enhancedScroller.ScrollRect.content.AddWidth(collumSize);
      }
      view.enhancedScroller.ReloadData(GetFixedPosition());
      return;
    }
    if (position.x < GetFixedPosition()) {
      RemoveEmptyCell(cellDatas.Count - gameStateData.musicLength);
    }
  }

  private NodeCollumTileData nodeToGetSize = new NodeCollumTileData();
  private float GetNodeCollumSize() {
    return nodeToGetSize.GetCellViewSize();
  }

  private float GetFixedPosition() {
    return (view.enhancedScroller.ScrollSize - gameStateData.musicLength * GetNodeCollumSize()) / view.enhancedScroller.ScrollSize;
  }

  public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex) {
    EnhancedScrollerCellView cellView;
    if (cellDatas[dataIndex] is NodeCollumTileData) {
      cellView = scroller.GetCellView(view.nodeCollumViewPrefab);
    } else {
      cellView = scroller.GetCellView(view.melodyViewPrefab);
    }
    cellView.SetData(dataIndex, cellDatas[dataIndex]);

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
      AddNewNodeCollum();
    }

    view.enhancedScroller.Delegate = this;
    view.enhancedScroller.ReloadData();
  }

  public void AddNewNodeCollum() {
    NodeCollumTileData nodeCollumData = new NodeCollumTileData();
    gameStateData.collumDatas.Add(nodeCollumData);
    cellDatas.Add(nodeCollumData);
  }

  public void ContainerMoveUpdate(float deltaTime) {
    if (!view.musicBar.gameObject.activeSelf) {
      view.musicBar.gameObject.SetActive(true);
      view.musicBar.SetLocalPositionX(0);
    }

    view.enhancedScroller.ScrollRect.AddHorizontalPosition(gameStateData.musicSpeed * deltaTime / view.enhancedScroller.ScrollSize);
    if (view.enhancedScroller.ScrollRect.horizontalNormalizedPosition >= 1) {
      view.musicBar.AddLocalPositionX(gameStateData.musicSpeed * deltaTime);
    }
  }

  void Update() {
    if (gameStateData.isPlaying) {
      float deltaTime = Time.deltaTime;
      ContainerMoveUpdate(deltaTime);
    }
  }

  public void RemoveEmptyCell(int minIndex = 0) {
    while (true) {
      if (cellDatas.Count <= gameStateData.musicLength + 1|| cellDatas.Count <= minIndex) {
        return;
      }
      var data = cellDatas[cellDatas.Count - 1];
      if (!(data is NodeCollumTileData)) {
        return;
      }

      NodeCollumTileData nodeCollumTileData = data as NodeCollumTileData;
      if (nodeCollumTileData.emoDatas.Exists(emoData => emoData != null)) {
        return;
      }
      RemoveLastNodeCollum();
      view.enhancedScroller.ScrollRect.content.AddWidth(-nodeCollumTileData.GetCellViewSize());
    }
  }

  private void RemoveLastNodeCollum() {
    cellDatas.RemoveAt(cellDatas.Count - 1);
    gameStateData.collumDatas.RemoveAt(gameStateData.collumDatas.Count - 1);
  }

  public void MoveMusicStaff(float position) {
    view.enhancedScroller.ScrollRect.horizontalNormalizedPosition = Mathf.Min(1, Mathf.Max(0, position));
  }

  private float GetPlayMusicTime() {
    return view.enhancedScroller.ScrollSize / gameStateData.musicSpeed - 753 / gameStateData.musicSpeed;
  }

  public int GetStaffLength() {
    return cellDatas.Count - 1;
  }

}