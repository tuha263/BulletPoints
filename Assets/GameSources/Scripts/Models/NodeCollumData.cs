using System.Collections.Generic;

public class NodeCollumTileData : EnhancedScrollerCellData {
  public const int AmountOfNode = 15;

  public List<EmoTileData> emoDatas { get; set; }

  public int amountOfCollum { get; set; }
  public int columnIndex { get; private set; }

  public bool isSetable;

  public NodeCollumTileData(int columnIndex = -1, int tempo = 4) {
    this.columnIndex = columnIndex;
    this.columnIndex = this.columnIndex;
    emoDatas = new List<EmoTileData>();
    for (int i = 0; i < AmountOfNode; i++) {
      emoDatas.Add(null);
    }

    int numOfNode = tempo / 4;
    isSetable = columnIndex % (4 / numOfNode) == 0;
  }


  public override float GetCellViewSize() {
    return 80;
  }
} 