using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

public class MainGameContext : MVCSContext {
  public MainGameContext() : base() {}

  public MainGameContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping) {}

  protected override void mapBindings() {

    //Command
    commandBinder.Bind<SelectEmoSignal>().To<SelectEmoCommand>().Pooled();

    //Model
    injectionBinder.Bind<IGameStateData>().To<GameStateData>().ToSingleton();
    injectionBinder.Bind<MainGameContext>().To(this).CrossContext();

    //view - mediator
    mediationBinder.Bind<EmoListView>().To<EmoListMediator>();
    mediationBinder.Bind<EmoTileView>().To<EmoTileMediator>();
    mediationBinder.Bind<StaffView>().To<StaffMediator>();
    mediationBinder.Bind<NodeCollumTileView>().To<NodeCollumTileMediator>();
    mediationBinder.Bind<NodeTileView>().To<NodeTileMediator>();
    mediationBinder.Bind<MusicFieldView>().To<MusicFieldMediator>();
    mediationBinder.Bind<MelodyTileView>().To<MelodyTileMediator>();
    mediationBinder.Bind<CurrentEmoView>().To<CurrentEmoMediator>();

  }

  protected override void addCoreComponents() {
    base.addCoreComponents();
    injectionBinder.Unbind<ICommandBinder>();
    injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
  }
}