using System.Collections.Generic;
using AudioHelm;

public enum GameState {
  Play,
  Stop
}

public interface IGameStateData {
  int score { get; set; }
  EmoTileData currentEmo { get; set; }

  List<NodeCollumTileData> collumDatas { get; set; }
  bool isPlaying { get; set; }
  bool isLoop { get; set; }
  int channel { get; set; }
  int musicLength { get; set; }
  float musicSpeed { get; set; }
  GameState gameState { get; set; }
  int prepairCollumOffset { get; set; }
  int staffLength { get; set; }
  //View Option
  Sequencer.Division division { get; set; }
  int tempo { get; set; }
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

  public GameStateData(bool isPlaying, bool isLoop) {
    this.isPlaying = isPlaying;
    this.isLoop = isLoop;

  }
  public bool isPlaying { get; set; }

  public bool isLoop { get; set; }

  public int channel { get; set; }

  public int musicLength { get; set; }
  public Sequencer.Division division { get; set; }

  public float musicSpeed { get; set; }

  public GameState gameState { get; set; }

  public int prepairCollumOffset { get; set; }

  public int staffLength { get; set; }

  public int tempo { get; set; }

  public GameStateData() {
    collumDatas = new List<NodeCollumTileData>();
    musicLength = 16;
    musicSpeed = 120;
  }
}