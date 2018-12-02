using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class LoadDataMediator : EventMediator
{
    [Inject] public LoadDataView view { get; set; }
    [Inject] public IGameStateData gameStateData { get; set; }

    private string _saveName;

    public override void OnRegister()
    {
        view.Init(OnLoad, OnClose);
        dispatcher.AddListener(GameEvent.OpenLoadGame, OnOpen);
        dispatcher.AddListener(GameEvent.OnChooseSaveData, OnChooseSaveName);
        OnClose();
    }

    private void OnChooseSaveName(IEvent payload)
    {
        _saveName = (string) payload.data;
    }

    private void OnOpen()
    {
        view.OnOpen();
    }

    public void OnClose()
    {
        view.OnClose();
    }

    public void OnLoad()
    {
        view.OnClose();
        GameStateData loadGameData = PersistDataHelper.LoadData(_saveName);
        dispatcher.Dispatch(GameEvent.DoLoadgame);
    }
}