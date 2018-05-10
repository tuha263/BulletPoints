using strange.extensions.context.impl;
using UnityEngine;
using UnityEngine.Audio;

public class MainGameRoot : ContextView {
  void Awake() {
    MainGameContext mainGameContext = new MainGameContext(this, true);
    context = mainGameContext;
    context.Start();
  }
}