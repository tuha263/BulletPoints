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
  [Inject]
  public ITimeSigsDataManager timeSigsDataManager { get; set; }

  [Inject]
  public IClefsDataManager clefDataManager { get; set; }

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
  }

  public void SetTimeSig(db_TimeSigsData data) {
    timeSignIcon.sprite = Resources.Load<Sprite>("TimeSigs/" + data);
  }

  public void SetClef() {

  }
}