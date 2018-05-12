using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class StaffView : View {
  [SerializeField]
  private GameObject line;

  [SerializeField]
  private int amountOfLine;

  [SerializeField]
  private Color subLineColor;
  [SerializeField]

  private Color mainLineColor;

  public void PopulateLines() {
    for (int i = 0; i < amountOfLine; i++) {
      Image lineImage = gameObject.InstantiateAsChild(line).GetComponent<Image>();
      if (i == 0 || i == 1 || i == 7) {
        lineImage.color = subLineColor;
      } else {
        lineImage.color = mainLineColor;
      }
    }
  }

}