using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class ChangeTempoCommand : Command {
  [Inject]
  public int tempo { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject(ContextKeys.CONTEXT_DISPATCHER)]
  public IEventDispatcher dispatcher { get; set; }
  public override void Execute() {
    gameStateData.tempo = tempo;
    int numOfNode = gameStateData.tempo / 4;
    //SetSetable((dataIndex - 1) % 4 < numOfNode); 
    gameStateData.collumDatas.ForEach(column => column.isSetable = column.columnIndex % (4 / numOfNode) == 0);
    dispatcher.Dispatch(GameEvent.OnChangeTempo);
  }
}