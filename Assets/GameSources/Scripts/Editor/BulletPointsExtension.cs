using System.Collections.Generic;
using System.Linq;
using AudioHelm;
using GDataDB;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityQuickSheet;

public class BulletPointsExtension : Editor {
  [MenuItem("BulletPoints/Import Data")]
  static void ImportData() {
    db_Emo data = Resources.Load<db_Emo>("GoogleDatas/db_Emo");
    AudioMixer audioMixer = Resources.Load<AudioMixer>("AudioMixers/BulletPoints");
    data.dataArray.ToList().ForEach(emoData => {
      AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups(emoData.Patch);
      if (audioMixerGroups.Length > 0) {
        AudioMixerGroup audioMixerGroup = audioMixerGroups[0];
        Debug.Log(emoData.Patch + ": " + emoData.Channel);
        audioMixerGroup.audioMixer.SetFloat("Channel", emoData.Channel);
        Debug.Log(audioMixerGroup.audioMixer.name);
      }
    });
  }

  [MenuItem("BulletPoints/Reload Data")]

  static void ReloadData() {
    db_EmoEditor.ReLoad();
  }

  void Start() {
    Debug.LogError("start");
  }
}

public static class GoogleSheetExtension {

}