using strange.extensions.mediation.impl;

public class SaveInputMediator : EventMediator
{
    [Inject] public SaveInputView view { get; set; }
    [Inject] public IGameStateData gameStateData { get; set; }

    public override void OnRegister()
    {
        view.Init(OnSave, OnClose);
        dispatcher.AddListener(GameEvent.OpenSaveGame, OnOpen);
        OnClose();
    }

    private void OnSave()
    {
        view.GetSaveName();
        PersistDataHelper.SaveData(view.GetSaveName(), (GameStateData) gameStateData);
    }
    
    private void OnClose()
    {
        view.OnClose();
    }

    public void OnOpen()
    {
        view.OnOpen();
    }
}