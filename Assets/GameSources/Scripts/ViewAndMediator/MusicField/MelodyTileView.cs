using EnhancedUI.EnhancedScroller;

public class MelodyTileView : EnhancedScrollerCellView {
  private MelodyTileData data;
  public override void SetData(EnhancedScrollerCellData data) {
    this.data = data as MelodyTileData;
  }
}