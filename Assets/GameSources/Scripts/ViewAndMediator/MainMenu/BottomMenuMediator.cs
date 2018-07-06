using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
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
    view.PlayButton.onClick.AddListener(OnClickPlayButton);
    view.LoopButton.onClick.AddListener(OnClickLoopButton);
    playText = view.PlayButton.GetComponentInChildren<Text>();
    loopText = view.LoopButton.GetComponentInChildren<Text>();
    Init();

    dispatcher.AddListener(GameEvent.OnChangeTempo, OnChangeTempo);
  }

  private void OnChangeTempo(IEvent payload) {
    view.SetTempoText(gameStateData.tempo);
    view.HideTempoList();
  }

  private void Init() {
    view.Init();
    gameStateData.isPlaying = false;
    gameStateData.isLoop = true;
    SetPlayText();
    SetLoopText();
  }

  public void OnClickPlayButton() {
    if (!gameStateData.isPlaying) {
      playMusicSignal.Dispatch();
    } else {
      StopMusicSignal.Dispatch();
    }
    SetPlayText();
  }

  private void OnClickLoopButton() {
    gameStateData.isLoop = !gameStateData.isLoop;
    dispatcher.Dispatch(GameEvent.SetMusicLoop);
    SetLoopText();
  }

  public void SetPlayText() {
    playText.text = gameStateData.isPlaying ? "Stop" : "Play";
  }

  public void SetLoopText() {
    loopText.text = gameStateData.isLoop ? "Loop" : "NoLoop";
  }
}