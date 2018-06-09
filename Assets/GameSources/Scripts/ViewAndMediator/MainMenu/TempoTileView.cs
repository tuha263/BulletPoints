using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class TempoTileView : View {
  public int tempo { get; private set; }
  public string tempoString { get; private set; }
  public Button button;
  [SerializeField]
  private Text valueText;
  public void Init(int tempo) {
    this.tempo = tempo;
    tempoString = BulletPointExtension.GetTempoString(tempo);
    valueText.text = tempoString;
  }
}