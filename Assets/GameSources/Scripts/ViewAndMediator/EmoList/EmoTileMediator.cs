using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class EmoTileMediator : EventMediator
{
    [Inject] public EmoTileView view { get; set; }

    [Inject] public SelectEmoSignal selecEmoSignal { get; set; }

    [Inject] public IGameStateData gameStateData { get; set; }

    public override void OnRegister()
    {
        view.SetOnClickListener(OnClick);
        view.setSelected(false);
        dispatcher.AddListener(GameEvent.OnSelectEmo, OnSelectEmo);
    }

    private void OnSelectEmo(IEvent payload)
    {
        if (payload.data != this)
        {
            view.setSelected(false);
        }
    }

    public void OnClick()
    {
        selecEmoSignal.Dispatch(view.GetData());
        dispatcher.Dispatch(GameEvent.OnSelectEmo, this);
        view.setSelected(true);

    }
}