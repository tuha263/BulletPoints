using AudioHelm;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class StopMusicCommand : Command {
  [Inject]
  public AudioHelmClock helmClock { get; set; }

  [Inject(ContextKeys.CONTEXT_DISPATCHER)]
  public IEventDispatcher dispatcher { get; set; }
  public override void Execute() {
    helmClock.pause = true;
    helmClock.Reset();
    dispatcher.Dispatch(GameEvent.OnStopMusic);
  }
}