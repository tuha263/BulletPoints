using UnityEngine;

public abstract class GoogleSheetDataManager<T> where T : Object {
  public const string directory = "GoogleDatas/";
  private T _Data = null;

  public GoogleSheetDataManager() {
    _Data = Resources.Load<T>(path);
  }

  protected T Data {
    get {
      if (_Data == null) {
        _Data = Resources.Load<T>(path);
      }
      return _Data;
    }
  }
  private string path { get { return directory + GetFileName(); } }
  protected abstract string GetFileName();
}