using System.Collections;
using System.Collections.Generic;
using System.Linq;
using strange.extensions.mediation.impl;
using UnityEngine;

public class EmoListMediator : Mediator {
  [Inject]
  public EmoListView view { get; set; }
  private List<Sprite> emoSprites;

  public override void OnRegister() {
    LoadEmosFromResource();
  }

  private void LoadEmosFromResource() {
    emoSprites = Resources.LoadAll<Sprite>("Emos").ToList();
    view.PopulateEmos(emoSprites);
  }
}