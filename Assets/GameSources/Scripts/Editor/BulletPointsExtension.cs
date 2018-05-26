using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        PropertyInfo effectInfo = audioMixerGroup.GetType().GetProperty("effects");
        Debug.Log(effectInfo.Name);
        audioMixerGroup.GetType().GetProperties().ToList().ForEach(e => { Debug.Log(e); });
        effectInfo.GetIndexParameters().ToList().ForEach(e => { Debug.Log(e); });
        effectInfo.GetOptionalCustomModifiers().ToList().ForEach(e => { Debug.Log(e); });
        effectInfo.GetRequiredCustomModifiers().ToList().ForEach(e => { Debug.Log(e); });
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