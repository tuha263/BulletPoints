using AudioHelm;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MusicManagerView : View {
  [SerializeField]
  public HelmSequencer sequencer;
  [SerializeField]
  private int increase;
  [SerializeField]
  private int startingNote;

  [Inject]
  public IStaffSettingDataManager staffSettingData { get; set; }

  public void Init() {
    ClearSequencer();
  }

  public void ClearSequencer() {
    sequencer.Clear();
  }
  public void Play() {
  }
  public void Stop() {
  }

  public void SetLoop(bool isLoop) {
    Debug.Log(isLoop);
    sequencer.loop = isLoop;
  }

  public int GetMusicLength() {
    return sequencer.length;
  }

  public Sequencer.Division GetMusicDivision() {
    return sequencer.division;
  }

  public void AddNode(int collum, int index, EmoTileData emoTileData) {
    sequencer.AddNote(emoTileData.note + staffSettingData.Datas[NodeCollumTileData.AmountOfNode - 1 - index].Noteadditional, collum, collum + emoTileData.data.Notelength, 1);
  }
}