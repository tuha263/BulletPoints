using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AudioHelm;
using GDataDB;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityQuickSheet;

public class BulletPointEditor {
  private const string channel_param_post_fix = "_Channel";
  [MenuItem("BulletPoints/Import Data")]
  static void ImportData() {
    db_Emo data = Resources.Load<db_Emo>("GoogleDatas/db_Emo");
    AudioMixer audioMixer = Resources.Load<AudioMixer>("AudioMixers/BulletPoints");
    Debug.Log(audioMixer.GetHashCode());
    data.dataArray.ToList().ForEach(emoData => {
      AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups(emoData.Patch);
      if (audioMixerGroups.Length > 0) {
        AudioMixerGroup audioMixerGroup = audioMixerGroups[0];
      }
      float a;
      audioMixer.GetFloat(emoData.Patch + channel_param_post_fix, out a);
      Debug.Log(emoData.Patch + channel_param_post_fix + ": " + a + " -> " + emoData.Channel);

      audioMixer.SetFloat(emoData.Patch + channel_param_post_fix, emoData.Channel);
    });

  }

  [MenuItem("BulletPoints/Reload Data")]

  static void ReloadData() {
    db_EmoEditor.ReLoad();
    db_ClefsEditor.ReLoad();
    db_TimeSigsEditor.ReLoad();
  }
}