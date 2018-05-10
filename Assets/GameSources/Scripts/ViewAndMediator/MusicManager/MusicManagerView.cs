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

  public void Init() {
    ClearSequencer();
    sequencer.enabled = false;
  }

  public void ClearSequencer() {
    sequencer.Clear();
  }
  public void Play() {
    sequencer.enabled = true;
  }
  public void Stop() {
    sequencer.enabled = false;
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
    sequencer.AddNote(emoTileData.note + index, collum, collum + 1, 1);
  }
}