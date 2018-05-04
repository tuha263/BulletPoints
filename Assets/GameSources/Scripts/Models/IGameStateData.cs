using System.Collections.Generic;

public interface IGameStateData {
  int score { get; set; }
  EmoTileData currentEmo { get; set; }

  List<NodeCollumTileData> collumDatas { get; set; }
}

public class GameStateData : IGameStateData {
  public int _scoce;
  public int score {
    get { return _scoce; }
    set { _scoce = value; }
  }

  //Selected emo
  public EmoTileData _currentEmo;

  public EmoTileData currentEmo {
    get { return _currentEmo; }
    set { _currentEmo = value; }
  }

  public List<NodeCollumTileData> collumDatas { get; set; }

  public GameStateData() {
    collumDatas = new List<NodeCollumTileData>();
  }
}