using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class CountPanelMediator : EventMediator
{
    [Inject] public CountPanelView view { get; set; }

    [Inject] public IGameStateData gameStateData { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(GameEvent.OnCount, OnCountToPlay);
        dispatcher.AddListener(GameEvent.OnStartCount, OnStartCount);

        gameObject.SetActive(false);
    }

    private void OnStartCount(IEvent payload)
    {
        gameObject.SetActive(true);
        //    view.SetText(gameStateData.playDelayTime.ToString());
        view.SetText("1");
    }

    private void OnCountToPlay(IEvent payload)
    {
        var timeRemain = (int) payload.data;
        if (timeRemain <= 0)
        {
            gameObject.SetActive(false);
            return;
        }

        view.SetText((gameStateData.currentTimeSig.Count - timeRemain + 1).ToString());
    }
}