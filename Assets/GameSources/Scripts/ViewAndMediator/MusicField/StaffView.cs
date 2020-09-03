using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class StaffView : View {
  [SerializeField]
  private GameObject line;

  [SerializeField]
  private int amountOfLine;
  [SerializeField]
  private VerticalLayoutGroup verticalLayoutGroup;

  [Inject] public IGameStateData gameStateData { get; set; }

  public void PopulateLines()
  {
    gameStateData.amountOfLine = amountOfLine;
    gameStateData.fieldHeight = (transform as RectTransform).GetHeight();
    gameStateData.fieldTopPadding = verticalLayoutGroup.padding.top;
    gameStateData.feidlBotPadding = verticalLayoutGroup.padding.bottom;
    
    for (int i = 0; i < amountOfLine; i++) {
      StaffLineView staffLine = gameObject.InstantiateAsChild(line).GetComponent<StaffLineView>();
      // 2 line above and 1 line below
      if (i < 2 || i == amountOfLine - 1) {
        staffLine.Init(false);
      } else {
        staffLine.Init(true);
      }
    }
  }

}