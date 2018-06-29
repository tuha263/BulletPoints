using System;
using System.Collections.Generic;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum NotePositionType {
  Left,
  Right,
  Center
}

public class NodeTileView : View {
  private const float MOVE_TIME = 0.3f;

  private Image icon { get { return icons[2]; } }

  [SerializeField]
  private List<Image> icons;
  [SerializeField]
  private Button button;
  public EmoTileData emoTileData { get { return gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[index]; } }

  public NodeCollumTileView nodeCollumTileView { get; private set; }
  public int index { get; private set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }
  public NotePositionType positionType;

  private bool isSetable;

  public void AddOnclickListener(UnityAction action) {
    button.onClick.AddListener(action);
  }  
  public void SetData(EmoTileData emoTileData) {
    icon.transform.SetLocalPositionX(0);
    positionType = NotePositionType.Center;
    icon.color = emoTileData == null ? new Color(255, 255, 255, 0) : new Color(255, 255, 255, 255);
    if (emoTileData == null) {
      if (!isSetable) {
        SetSetable(isSetable);
      }
      return;
    }
    icon.sprite = emoTileData.sprite;
  }

  public void MoveNoteToLeft() {
    icon.transform.DOLocalMoveX(icons[0].transform.localPosition.x, MOVE_TIME);
    positionType = NotePositionType.Left;

  }
  public void MoveNoteToRight() {
    icon.transform.DOLocalMoveX(icons[1].transform.localPosition.x, MOVE_TIME);
    positionType = NotePositionType.Right;
  }

  public void MoveToNoteToCenter() {
    icon.transform.DOLocalMoveX(0, MOVE_TIME);
    positionType = NotePositionType.Center;
  }

  public void OnClick() {
    //Todo - do move effect
  }

  public void Init(int index, NodeCollumTileView nodeCollumTileView) {
    this.nodeCollumTileView = nodeCollumTileView;
    this.index = index;
  }

  public void SetSetable(bool isSetable) {
    this.isSetable = isSetable;
    if (emoTileData != null && isSetable == false) {
      return;
    }
    button.image.color = isSetable ? new Color(255, 255, 255, 0) : new Color(0, 0, 0, 50);
    button.interactable = isSetable;
  }

  public void OnPlay() {
    if (emoTileData == null) {
      return;
    }
    transform.DOScale(Vector3.one * 1.2f, 0.2f).OnComplete(() => transform.DOScale(Vector3.one, 0.2f));
  }
}