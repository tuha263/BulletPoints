using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class BottomMenuMediator : EventMediator {
  [Inject]
  public BottomMenuView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public PlayMusicSignal playMusicSignal { get; set; }

  [Inject]
  public StopMusicSignal StopMusicSignal { get; set; }

  private Text playText;
  private Text loopText;

  public override void OnRegister() {
    view.playButton.onClick.AddListener(OnClickPlayButton);
    view.loopButton.onClick.AddListener(OnClickLoopButton);
    view.saveButton.onClick.AddListener(OnClickSaveButton);
    view.loadButotn.onClick.AddListener(OnClickLoadButton);
    playText = view.playButton.GetComponentInChildren<Text>();
    loopText = view.loopButton.GetComponentInChildren<Text>();
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

  private void OnChangeTimeSig(IEvent payload) {
    view.OnChangeTimeSig();
  }

  private void OnChangeTempo(IEvent payload) {
    view.SetTempoText(gameStateData.tempo);
    view.HideTempoList();
  }

  private void Init() {
    view.Init();
    gameStateData.isPlaying = false;
    gameStateData.isLoop = true;
    SetPlayText(gameStateData.isPlaying);
    SetLoopText();
  }

  public void OnClickPlayButton() {
    SetPlayText(!gameStateData.isPlaying);
    if (!gameStateData.isPlaying) {
      playMusicSignal.Dispatch();
    } else {
      StopMusicSignal.Dispatch();
    }
  }

  private void OnClickLoopButton() {
    gameStateData.isLoop = !gameStateData.isLoop;
    //dispatcher.Dispatch(GameEvent.SetMusicLoop);
    SetLoopText();
  }

  public void SetPlayText(bool isPlaying) {
    playText.text = isPlaying ? "Stop" : "Play";
  }

  public void SetLoopText() {
    loopText.text = gameStateData.isLoop ? "Loop" : "NoLoop";
  }
}