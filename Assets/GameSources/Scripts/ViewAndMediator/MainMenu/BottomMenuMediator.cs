using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuMediator : EventMediator
{
    [Inject] public BottomMenuView view { get; set; }
    [Inject] public IGameStateData gameStateData { get; set; }
    [Inject] public PlayMusicSignal playMusicSignal { get; set; }
    [Inject] public StopMusicSignal StopMusicSignal { get; set; }



    public override void OnRegister()
    {
        view.playButton.onClick.AddListener(OnClickPlayButton);
        view.loopButton.onClick.AddListener(OnClickLoopButton);
        view.saveButton.onClick.AddListener(OnClickSaveButton);
        view.loadButton.onClick.AddListener(OnClickLoadButton);
        Init();

        dispatcher.AddListener(GameEvent.DoStopOrPlayMusic, DoStopOrPlayMusic);
        dispatcher.AddListener(GameEvent.OnChangeTempo, OnChangeTempo);
        dispatcher.AddListener(GameEvent.OnChangeTimeSig, OnChangeTimeSig);
    }

    private void OnClickLoadButton()
    {
        dispatcher.Dispatch(GameEvent.OpenLoadGame);
    }

    private void OnClickSaveButton()
    {
        dispatcher.Dispatch(GameEvent.OpenSaveGame);
    }

    private void DoStopOrPlayMusic(IEvent payload)
    {
        OnClickPlayButton();
    }

    private void OnChangeTimeSig(IEvent payload)
    {
        view.OnChangeTimeSig();
    }

    private void OnChangeTempo(IEvent payload)
    {
        view.SetTempoText(gameStateData.tempo);
        view.HideTempoList();
    }

    private void Init()
    {
        view.Init();
        gameStateData.isPlaying = false;
        gameStateData.isLoop = true;
        Play(gameStateData.isPlaying);
        SetLoopText(gameStateData.isLoop);
    }

    public void OnClickPlayButton()
    {
        Play(!gameStateData.isPlaying);
        if (!gameStateData.isPlaying)
        {
            playMusicSignal.Dispatch();
        }
        else
        {
            StopMusicSignal.Dispatch();
        }
    }

    private void OnClickLoopButton()
    {
        gameStateData.isLoop = !gameStateData.isLoop;
        //dispatcher.Dispatch(GameEvent.SetMusicLoop);
        SetLoopText(gameStateData.isLoop);
    }

    public void Play(bool isPlaying)
    {
        view.Play(isPlaying);
    }

    public void SetLoopText(bool isLooping)
    {
        view.Loop(isLooping);
    }
}