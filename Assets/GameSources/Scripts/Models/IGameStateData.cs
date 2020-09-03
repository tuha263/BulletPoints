using System;
using System.Collections.Generic;
using System.Linq;
using AudioHelm;

public enum GameState
{
    Play,
    Stop
}

public interface IGameStateData
{
    int score { get; set; }
    EmoTileData currentEmo { get; set; }

    List<NodeCollumTileData> collumDatas { get; set; }
    bool isPlaying { get; set; }
    bool isLoop { get; set; }
    int channel { get; set; }
    int musicLength { get; set; }
    float musicSpeed { get; set; }

    GameState gameState { get; set; }

    //View Option
    int tempo { get; set; }
    db_ClefsData currentClef { get; set; }
    db_TimeSigsData currentTimeSig { get; set; }
    List<int> divisionList { get; }
    List<int> beatLength { get; }
    List<string> saveDataList { get; }
    List<EmoTileData> emoTileDataList { get; set; }
    float fieldHeight { get; set; }
    int fieldTopPadding { get; set; }
    int feidlBotPadding { get; set; }
    int amountOfLine { get; set; }
}

public class GameStateData : IGameStateData
{
    public int _scoce;

    public int score
    {
        get { return _scoce; }
        set { _scoce = value; }
    }

    //Selected emo
    public EmoTileData _currentEmo;

    public EmoTileData currentEmo
    {
        get { return _currentEmo; }
        set { _currentEmo = value; }
    }

    public List<NodeCollumTileData> collumDatas { get; set; }

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

    private db_TimeSigsData _currentTimeSig;

    public db_TimeSigsData currentTimeSig
    {
        get { return _currentTimeSig; }
        set
        {
            _currentTimeSig = value;
            _divisionList = value.Divisonlist.Select(e => int.Parse(e.Split('/')[1])).ToList();
            var sum = 0;
            _beatLength = value.Beatlength.Select(e =>
            {
                sum += e;
                return sum;
            }).ToList();
            var index = 0;
            while (sum < value.Sequencemeasurelength)
            {
                sum += value.Beatlength[index];
                _beatLength.Add(sum);
                index = (index + 1) % value.Beatlength.Length;
            }
        }
    }

    private List<int> _divisionList;

    public List<int> divisionList
    {
        get { return _divisionList; }
    }

    private List<int> _beatLength;

    public List<int> beatLength
    {
        get { return _beatLength; }
    }

    public List<string> saveDataList { get; }
    public List<EmoTileData> emoTileDataList { get; set; }
    
    public float fieldHeight { get; set; }
    public int fieldTopPadding { get; set; }
    public int feidlBotPadding { get; set; }
    public int amountOfLine { get; set; }

    public GameStateData()
    {
        collumDatas = new List<NodeCollumTileData>();
        saveDataList = new List<string>();
        musicLength = 16;
        musicSpeed = 120;
    }
}