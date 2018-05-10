using System;
using AudioHelm;
using UnityEngine;
using UnityEngine.Audio;

public class EmoTileData : EnhancedScrollerCellData {
  public Sprite sprite;
  public AudioMixerGroup audioMixerGroup;
  public HelmSequencer sequencer;
  public readonly int note;
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