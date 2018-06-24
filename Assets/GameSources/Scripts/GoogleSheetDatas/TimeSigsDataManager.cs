using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TimeSigsType {
  _2_4,
  _3_4,
  _4_4,
  _5_4,
  _7_4,
  _5_8,
  _7_8
}

public interface ITimeSigsDataManager {
  List<db_TimeSigsData> Datas { get; }
  int Length { get; }
}
public class TimeSigsDataManager : GoogleSheetDataManager<db_TimeSigs>, ITimeSigsDataManager {
  public int Length {
    get {
      return Data.dataArray.Length;
    }
  }

  private List<db_TimeSigsData> _Datas = null;

  public List<db_TimeSigsData> Datas {
    get {
      if (_Datas == null) {
        _Datas = Data.dataArray.ToList();
      }
      return _Datas;
    }
  }

  protected override string GetFileName() {
    return "db_TimeSigs";
  }

  private static Sprite _Sprite = null;
  public static Sprite LoadSprite(db_TimeSigsData data){
    _Sprite = Resources.Load<Sprite>("TimeSigs/" + data.Texture);
    return _Sprite;
  }
}