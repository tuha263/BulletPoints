using strange.extensions.mediation.impl;

public class SaveItemMediator : EventMediator
{
    [Inject] public SaveItemView view { get; set; }

    public override void OnRegister()
    {
        view.Init(Onclick);
    }

    private void Onclick()
    {
        dispatcher.Dispatch(GameEvent.OnChooseSaveData, view.GetSaveName());
    }
}