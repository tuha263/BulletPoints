using System;
using AudioHelm;
using UnityEngine;
using UnityEngine.Audio;

public class EmoTileData : EnhancedScrollerCellData {
  public Sprite sprite;
  public AudioMixerGroup audioMixerGroup;
  public Sequencer sequencer;
  private int _note;
  public int note { get { return _note + 12; } private set {_note = value; } }
  public readonly SoundType soundType;

  public readonly db_EmoData data;

  public EmoTileData(db_EmoData data) {
    this.data = data;
    note = data.Note;
    soundType = (SoundType) Enum.Parse(typeof(SoundType), data.Soundtype);
  }

  public override float GetCellViewSize() {
    return 80f;
  }
}