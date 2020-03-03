using System.Collections.Generic;
using System.Linq;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.signal.impl;

public class LoadRecordSignal : Signal<List<List<int>>>
{
}

public class LoadRecordCommand : Command
{
    [Inject] public List<List<int>> recodeData { get; set; }
    [Inject] public IGameStateData gameStateData { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    [Inject] public StopMusicSignal stopMusicSignal { get; set; }

    public override void Execute()
    {
        stopMusicSignal.Dispatch();

        gameStateData.collumDatas.Clear();
        for (int index = 0; index < recodeData.Count; index++)
        {
            List<int> emoList = recodeData[index];
            var nodeColumnTileData = new NodeCollumTileData(index);
            gameStateData.collumDatas.Add(nodeColumnTileData);
            for (int emoIndex = 0; emoIndex < emoList.Count; emoIndex++)
            {
                int emoId = emoList[emoIndex];
                if (emoId != 0)
                {
                    nodeColumnTileData.emoDatas[emoIndex] =
                        gameStateData.emoTileDataList.First(tileData => tileData.data.ID == emoId);
                }
            }
        }

        dispatcher.Dispatch(GameEvent.OnLoadData);
    }
}