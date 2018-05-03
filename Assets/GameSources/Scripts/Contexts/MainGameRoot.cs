using strange.extensions.context.impl;

public class MainGameRoot : ContextView {
  void Awake() {
    context = new MainGameContext(this, true);
    context.Start();
  }
}