using System.Collections.Generic;
using System.Linq;

public enum SoundType {
  Sequencer,
  Drum
}

public interface IEmoDataManager {
  List<db_EmoData> Datas { get; }
  int Length { get; }
}
public class EmoDataManager : GoogleSheetDataManager<db_Emo>, IEmoDataManager {
  public int Length {
    get {
      return Data.dataArray.Length;
    }
  }
  private List<db_EmoData> _Datas = null;
  public List<db_EmoData> Datas {
    get {
      if (_Datas == null) {
        _Datas = Data.dataArray.ToList();
      }
      return _Datas;
    }
  }

  protected override string GetFileName() {
    return "db_Emo";
  }
}