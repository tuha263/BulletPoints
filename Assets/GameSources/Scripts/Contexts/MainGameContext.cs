using strange.extensions.context.impl;
using UnityEngine;

public class MainGameContext : MVCSContext {
  public MainGameContext() : base() {}

  public MainGameContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping) {}

  protected override void mapBindings() {

    //view - mediator
    mediationBinder.Bind<EmoListView>().To<EmoListMediator>();
    mediationBinder.Bind<EmoTileView>().To<EmoTileMediator>();
    mediationBinder.Bind<StaffView>().To<StaffMediator>();
  }
}