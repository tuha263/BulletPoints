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

  public EmoTileData emoTileData { get; private set; }

  [NonSerialized]
  public NodeCollumTileView nodeCollumTileView;
  private int index;

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public void AddOnclickListener(UnityAction action) {
    button.onClick.AddListener(action);
  }  
  public void SetData(EmoTileData data) {
    emoTileData = data;
    if (data == null) {
      return;
    }
    icon.color = data.sprite == null ? new Color(255, 255, 255, 0) : new Color(255, 255, 255, 255);
    icon.sprite = data.sprite;
  }

  public void OnClick(EmoTileData data){
    gameStateData.collumDatas[nodeCollumTileView.dataIndex].emoDatas[index] = data;
    SetData(data);
  }

  public void Reset() {
    emoTileData = null;
    icon.sprite = defaultSprite;
  }

  public void Init(int index) {
    this.index = index;
  }
}