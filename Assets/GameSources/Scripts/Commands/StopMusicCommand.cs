using AudioHelm;
using strange.extensions.command.impl;

public class StopMusicCommand : Command {
    [Inject]
    public AudioHelmClock helmClock{get; set;}
    public override void Execute(){
        helmClock.pause = true;
    }
}