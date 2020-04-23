using strange.extensions.mediation.impl;
using UnityEngine;

public class StaffView : View {
  [SerializeField]
  private GameObject line;

  [SerializeField]
  private int amountOfLine;

  public void PopulateLines() {
    for (int i = 0; i < amountOfLine; i++) {
      StaffLineView staffLine = gameObject.InstantiateAsChild(line).GetComponent<StaffLineView>();
      if (i == 0 || i == 1 || i == 7) {
        staffLine.Init(false);
      } else {
        staffLine.Init(true);
      }
    }
  }

}