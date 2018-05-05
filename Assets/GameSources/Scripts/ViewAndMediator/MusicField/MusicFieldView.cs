using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class MusicFieldView : View {

  public EnhancedScrollerCellView nodeCollumViewPrefab;

  public EnhancedScrollerCellView melodyViewPrefab;

  public EnhancedScroller enhancedScroller;
  [SerializeField]
  private MusicManagerView musicManagerPrefab;

  public void CreateMusicManager() {
    gameObject.InstantiateAsChild(musicManagerPrefab);
  }
}