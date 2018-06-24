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
  public IGameStateData gameStateData { get; set; }

  public void Init() {
    ClearSequencer();
  }

  public void ClearSequencer() {
    sequencer.Clear();
  }
  public void Play() {
    sequencer.ResetBeat();
  }
  public void Stop() {
    sequencer.ResetBeat();
  }

  public void SetLoop(bool isLoop) {
    sequencer.loop = isLoop;
  }

  public int GetMusicLength() {
    return sequencer.length;
  }

  public Sequencer.Division GetMusicDivision() {
    return sequencer.division;
  }

  public void AddNode(int collum, int index, EmoTileData emoTileData) {
    sequencer.AddNote(emoTileData.note + gameStateData.currentClef.Noteshigh[NodeCollumTileData.AmountOfNode - 1 - index], collum, collum + emoTileData.data.Notelength, 1);
  }
}