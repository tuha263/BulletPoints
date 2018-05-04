using System.Collections.Generic;

public class NodeCollumTileData : EnhancedScrollerCellData {
  public const int AmountOfNode = 9;

  public List<EmoTileData> emoDatas { get; set; }

  public int amountOfCollum { get; set; }

  public NodeCollumTileData() {
    emoDatas = new List<EmoTileData>();
    for (int i = 0; i < AmountOfNode; i++) {
      EmoTileData emoData = new EmoTileData();
      emoDatas.Add(emoData);
    }
  }
} 