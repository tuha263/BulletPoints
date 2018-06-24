using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ClefsType {
  Major,
  Minor,
  MajorPentatonic,
  MinorPentatonic,
  Chromatic
}
public interface IClefsDataManager {
  List<db_ClefsData> Datas { get; }
  int Length { get; }
}
public class ClefsDataManager : GoogleSheetDataManager<db_Clefs>, IClefsDataManager {
  public int Length {
    get {
      return Data.dataArray.Length;
    }
  }

  private List<db_ClefsData> _Datas = null;

  public List<db_ClefsData> Datas {
    get {
      if (_Datas == null) {
        _Datas = Data.dataArray.ToList();
      }
      return _Datas;
    }
  }
  private static Sprite _Sprite = null;
  public static Sprite LoadSprite(db_ClefsData data) {
    _Sprite = Resources.Load<Sprite>("Clefs/" + data.Texture);
    return _Sprite;
  }

  protected override string GetFileName() {
    return "db_Clefs";
  }

}