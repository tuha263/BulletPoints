using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

public class MelodyTileView : EnhancedScrollerCellView {
  private MelodyTileData data;
  [SerializeField]
  private Image clefIcon;
  [SerializeField]
  private Image timeSignIcon;

  [SerializeField]
  private GameObject clefRoot;
  [SerializeField]
  private GameObject clefTilePrefab;
  [SerializeField]
  private GameObject timeSigRoot;
  [SerializeField]
  private GameObject timeSigTilePrefab;
  [SerializeField]
  private GameObject listClefsRoot;
  [SerializeField]
  private GameObject listTimeSigRoot;

  [Inject]
  public ITimeSigsDataManager timeSigsDataManager { get; set; }

  [Inject]
  public IClefsDataManager clefDataManager { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void SetData(EnhancedScrollerCellData data) {
    this.data = data as MelodyTileData;
  }

  public void Init() {
    clefDataManager.Datas.ForEach(clef => {
      ClefTileView clefView = clefRoot.InstantiateAsChild(clefTilePrefab).GetComponent<ClefTileView>();
      clefView.Init(clef);
    });
    timeSigsDataManager.Datas.ForEach(timeSig => {
      TimeSigTileView timeSignView = timeSigRoot.InstantiateAsChild(timeSigTilePrefab).GetComponent<TimeSigTileView>();
      timeSignView.Init(timeSig);
    });
    gameStateData.currentTimeSig = timeSigsDataManager.Datas.Find(timeSig => timeSig.TIMESIGSTYPE == TimeSigsType._4_4);
    gameStateData.currentClef = clefDataManager.Datas.Find(clef => clef.CLEFSTYPE == ClefsType.Major);
    SetTimeSig(gameStateData.currentTimeSig);
    SetClef(gameStateData.currentClef);
  }

  private void SetTimeSig(db_TimeSigsData data) {
    timeSignIcon.sprite = TimeSigsDataManager.LoadSprite(data);
  }

  private void SetClef(db_ClefsData data) {
    clefIcon.sprite = ClefsDataManager.LoadSprite(data);
  }

  public void OnChangeTimeSig() {
    SetTimeSig(gameStateData.currentTimeSig);
    listTimeSigRoot.SetActive(false);
  }

  public void OnChangeClef() {
    SetClef(gameStateData.currentClef);
    listClefsRoot.SetActive(false);
  }
}