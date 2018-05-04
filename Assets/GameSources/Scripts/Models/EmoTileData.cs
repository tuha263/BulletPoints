using UnityEngine;

public class EmoTileData : EnhancedScrollerCellData {
  public Sprite sprite;

  public EmoTileData(Sprite sprite = null) {
    this.sprite = sprite;
  }
}