using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NodeTileView : View {
  private Image icon { get { return icons[index % 2]; } }

  [SerializeField]
  private List<Image> icons;
  [SerializeField]
  private Button button;
  private EmoTileData emoTileData { get { return gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[index]; } }

  public NodeCollumTileView nodeCollumTileView { get; private set; }
  public int index { get; private set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public void AddOnclickListener(UnityAction action) {
    button.onClick.AddListener(action);
  }  
  public void SetData(EmoTileData emoTileData) {
    icon.color = emoTileData == null ? new Color(255, 255, 255, 0) : new Color(255, 255, 255, 255);
    if (emoTileData == null) {
      return;
    }
    icon.sprite = emoTileData.sprite;
  }

  public void OnClick() {
    //Todo - do move effect
  }

  public void Init(int index, NodeCollumTileView nodeCollumTileView) {
    this.nodeCollumTileView = nodeCollumTileView;
    this.index = index;
  }
}