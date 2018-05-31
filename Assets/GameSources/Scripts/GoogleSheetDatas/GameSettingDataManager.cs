using System.Collections.Generic;
using System.Linq;

public interface IStaffSettingDataManager {
  List<db_StaffSettingData> Datas { get; }
  int Length { get; }
}

public class StaffSettingDataManager : GoogleSheetDataManager<db_StaffSetting>, IStaffSettingDataManager {
  private List<db_StaffSettingData> _Datas = null;
  public List<db_StaffSettingData> Datas {
    get {
      if (_Datas == null) {
        _Datas = Data.dataArray.ToList();
      }
      return _Datas;
    }
  }

  public int Length { get { return Data.dataArray.Length; } }

  protected override string GetFileName() {
    return "db_StaffSetting";
  }
}