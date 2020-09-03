using strange.extensions.context.impl;

public class LoadSceneRoot : ContextView {
  private void Awake() {
    LoadSceneContext loadSceneContext = new LoadSceneContext(this, true);
    context = loadSceneContext;
    context.Start();

    DontDestroyOnLoad(gameObject);
  }
}