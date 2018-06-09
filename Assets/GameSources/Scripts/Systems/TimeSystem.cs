using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public partial class MainGameRoot {

  private GameObject moveSystem;
  [Inject(ContextKeys.CONTEXT_DISPATCHER)]
  public IEventDispatcher dispatcher { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }
  void Update() {
    if (gameStateData != null && gameStateData.isPlaying) {
      dispatcher.Dispatch(GameEvent.OnTimeUpdate, Time.deltaTime);
    }
  }
}