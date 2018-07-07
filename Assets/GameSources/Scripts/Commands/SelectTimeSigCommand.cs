using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class SelectTimeSigCommand : Command {

  [Inject]
  public db_TimeSigsData timeSigData { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject(ContextKeys.CONTEXT_DISPATCHER)]
  public IEventDispatcher dispatcher { get; set; }

  public override void Execute() {
    gameStateData.currentTimeSig = timeSigData;
    gameStateData.musicLength = timeSigData.Sequencemeasurelength;
    dispatcher.Dispatch(GameEvent.OnChangeTimeSig);
  }
}