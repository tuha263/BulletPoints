using System;
using System.Collections.Generic;
using System.Linq;
using AudioHelm;
using DG.Tweening;
using EnhancedUI.EnhancedScroller;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Audio;

public class MusicFieldMediator : EventMediator, IEnhancedScrollerDelegate {
  [Inject]
  public MusicFieldView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public MainGameContext mainGameContext { get; set; }

  [Inject]
  public Dictionary<AudioMixerGroup, MusicManagerView> sequencerDic { get; set; }
  private List<EnhancedScrollerCellData> cellDatas;
  private float melodySize;
  private float collumSize;
  private float scrollCollumMoveAmount;
  private float barCollumMoveAmount;
  private float barScrollSize;
  private HelmSequencer sequencer;
  private int currentNote;

  public override void OnRegister() {
    mainGameContext.injectionBinder.Bind<MusicFieldMediator>().To(this).ToSingleton();
    view.enhancedScroller.ScrollRect.onValueChanged.AddListener(OnScroll);
    view.musicBar.gameObject.SetActive(false);
    melodySize = new MelodyTileData().GetCellViewSize();
    collumSize = new NodeCollumTileData().GetCellViewSize();

    dispatcher.AddListener(GameEvent.OnInitStaff, Init);
    dispatcher.AddListener(GameEvent.OnTimeUpdate, OnTimeUpdate);
    dispatcher.AddListener(GameEvent.OnPlayMusic, OnPlayMusic);
    dispatcher.AddListener(GameEvent.OnStopMusic, OnStopMusic);
  }

  private void OnStopMusic(IEvent payload) {
    // if (view.musicBar.gameObject.activeSelf) {
    //   view.musicBar.gameObject.SetActive(false);
    // }
    ResetScrollBar();
  }

  private void ResetScrollBar() {
    view.enhancedScroller.ScrollRect.SetHorizontalPosition(0);
    view.musicBar.SetLocalPositionX(0);
  }

  private void OnPlayMusic(IEvent payload) {
    currentNote = -1;
    sequencer = sequencerDic.Values.ToList().Find(e => e.sequencer != null).sequencer;
    scrollCollumMoveAmount = view.enhancedScroller.ScrollSize / collumSize;
    barCollumMoveAmount = sequencer.length - scrollCollumMoveAmount;
    barScrollSize = barCollumMoveAmount * collumSize;
    if (!view.musicBar.gameObject.activeSelf) {
      view.musicBar.gameObject.SetActive(true);
    }
  }

  private void OnTimeUpdate(IEvent payload) {
    float deltaTime = (float) payload.data;
    ContainerMoveUpdate(deltaTime);
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
    float currentPos = (float) sequencer.GetSequencerPosition();
    var realNote = (int) currentPos;
    if (realNote != currentNote) {
      currentNote = realNote;
      dispatcher.Dispatch(GameEvent.OnPlayNote, currentNote);
    }

    if (currentPos <= scrollCollumMoveAmount) {
      view.enhancedScroller.ScrollRect.SetHorizontalPosition(currentPos / scrollCollumMoveAmount);
      view.musicBar.SetLocalPositionX(0);
    } else {
      view.enhancedScroller.ScrollRect.SetHorizontalPosition(1);
      view.musicBar.SetLocalPositionX(barScrollSize * ((currentPos - scrollCollumMoveAmount) / barCollumMoveAmount));
    }
  }

  public void RemoveEmptyCell(int minIndex = 0) {
    while (true) {
      if (cellDatas.Count <= gameStateData.musicLength + 1 || cellDatas.Count <= minIndex) {
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