using AudioHelm;
using strange.extensions.context.impl;
using UnityEngine;

public class LoadSceneContext : MVCSContext {
  public LoadSceneContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping) {}
  protected override void mapBindings() {
    //Model
    injectionBinder.Bind<IGameStateData>().To<GameStateData>().ToSingleton().CrossContext();
    injectionBinder.Bind<IEmoDataManager>().To<EmoDataManager>().ToSingleton().CrossContext();
    injectionBinder.Bind<IClefsDataManager>().To<ClefsDataManager>().ToSingleton().CrossContext();
    injectionBinder.Bind<ITimeSigsDataManager>().To<TimeSigsDataManager>().ToSingleton().CrossContext();

    //Mediator
    mediationBinder.Bind<LoadingProgressView>().To<LoadingProgressMediator>();
  }
}