using strange.extensions.mediation.impl;
using UnityEngine;

public class StaffView : View {
  [SerializeField]
  private GameObject line;

  [SerializeField]
  private int amountOfLine;

  public void PopulateLines() {
    for (int i = 0; i < amountOfLine; i++) {
      gameObject.InstantiateAsChild(line);
    }
  }

}