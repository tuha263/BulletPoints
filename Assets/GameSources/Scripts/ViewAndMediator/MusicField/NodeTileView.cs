using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NodeTileView : View {
  [SerializeField]
  private Image icon;
  [SerializeField]
  private Button button;
  [SerializeField]
  private Sprite defaultSprite;

  private EmoTileData emoTileData { get { return gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[index]; } }

  [NonSerialized]
  public NodeCollumTileView nodeCollumTileView;
  public int index { get; private set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public void AddOnclickListener(UnityAction action) {
    button.onClick.AddListener(action);
  }  
  public void SetData() {
    icon.color = emoTileData == null ? new Color(255, 255, 255, 0) : new Color(255, 255, 255, 255);
    if (emoTileData == null) {
      return;
    }
    icon.sprite = emoTileData.sprite;
  }

  public void OnClick() {
    //because of melody so dataindex - 1
    SetData();
  }

  public void Reset() {
    icon.sprite = defaultSprite;
  }

  public void Init(int index) {
    this.index = index;
  }
}