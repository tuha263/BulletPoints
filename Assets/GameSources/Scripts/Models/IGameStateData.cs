using System;
using System.Collections.Generic;
using System.Linq;
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
  db_ClefsData currentClef { get; set; }
  db_TimeSigsData currentTimeSig { get; set; }
  int playDelayTime { get; set; }
  List<int> divisionList { get; }
  List<int> beatLength { get; }
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

  public db_ClefsData currentClef { get; set; }

  public int playDelayTime { get; set; }
  private db_TimeSigsData _currentTimeSig;
  public db_TimeSigsData currentTimeSig {
    get { return _currentTimeSig; }
    set {
      _currentTimeSig = value;
      _divisionList = value.Divisonlist.Select(e => Int32.Parse(e.Split('/') [1])).ToList();
      _beatLength = value.Beatlength.ToList();
    }
  }

  private List<int> _divisionList;
  public List<int> divisionList { get { return _divisionList; } }

  private List<int> _beatLength;
  public List<int> beatLength { get { return _beatLength; } }

  public GameStateData() {
    collumDatas = new List<NodeCollumTileData>();
    musicLength = 16;
    musicSpeed = 120;
    playDelayTime = 3;
  }
}