using UnityEngine;

public class EmoTileData : EnhancedScrollerCellData {
  public const float NodeLong = 4;
  public Sprite sprite;
  public int note;
  public float start;
  public float end;
  public float velocity = 1.0f;

  public EmoTileData(Sprite sprite = null) {
    this.sprite = sprite;
    note = 72;
  }

  public override float GetCellViewSize() {
    return 80f;
  }
}