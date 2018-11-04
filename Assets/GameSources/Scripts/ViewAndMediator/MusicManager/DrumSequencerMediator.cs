using strange.extensions.mediation.impl;

public class DrumSequencerMediator : Mediator
{
    [Inject] public DrumSequencerView view { get; set; }

    public override void OnRegister()
    {
        view.LoadDrumSounds();
    }
}