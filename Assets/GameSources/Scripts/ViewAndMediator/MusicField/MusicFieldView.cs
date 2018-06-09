using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class MusicFieldView : View {

  public EnhancedScrollerCellView nodeCollumViewPrefab;

  public EnhancedScrollerCellView melodyViewPrefab;

  public EnhancedScroller enhancedScroller;
  public RectTransform musicBar;
  public Text debugText;

  public float GetMinPosX() {
    return enhancedScroller.ScrollSize;
  }
}