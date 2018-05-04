using strange.extensions.context.impl;
using UnityEngine;

public class MainGameRoot : ContextView {
  void Awake() {
    MainGameContext mainGameContext = new MainGameContext(this, true);
    context = mainGameContext;
    context.Start();
  }
}