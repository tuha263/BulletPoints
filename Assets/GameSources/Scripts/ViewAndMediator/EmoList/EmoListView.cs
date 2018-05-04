using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class EmoListView : View, IEnhancedScrollerDelegate {
  [SerializeField]
  private EnhancedScroller scroller;
  [SerializeField]
  private ScrollRect scrollRect;

  [SerializeField]
  private EmoTileView emoTilePrefab;

  private List<EmoTileData> emoDatas;

  public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex) {
    EnhancedScrollerCellView cellView = scroller.GetCellView(emoTilePrefab);
    cellView.SetData(emoDatas[dataIndex]);
    return cellView;
  }

  public float GetCellViewSize(EnhancedScroller scroller, int dataIndex) {
    return 80f;
  }

  public int GetNumberOfCells(EnhancedScroller scroller) {
    return emoDatas.Count;
  }

  public void PopulateEmos(List<Sprite> sprites) {
    emoDatas = new List<EmoTileData>();
    sprites.ForEach(sprite => { emoDatas.Add(new EmoTileData(sprite)); });
    scroller.Delegate = this;
    scroller.ReloadData();
    ContentSizeFitter sizeFitter = scrollRect.content.gameObject.AddComponent<ContentSizeFitter>();
    sizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
    sizeFitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
  }
}