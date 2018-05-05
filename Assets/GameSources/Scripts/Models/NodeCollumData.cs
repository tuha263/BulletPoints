using System.Collections.Generic;

public class NodeCollumTileData : EnhancedScrollerCellData {
  public const int AmountOfNode = 4;

  public List<EmoTileData> emoDatas { get; set; }

  public int amountOfCollum { get; set; }

  public NodeCollumTileData() {
    emoDatas = new List<EmoTileData>();
    for (int i = 0; i < AmountOfNode; i++) {
      emoDatas.Add(null);
    }
  }

  public override float GetCellViewSize()
  {
    return 58.36f;
  }
} 