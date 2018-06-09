using System;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MusicManagerMediator : EventMediator {
  [Inject]
  public MusicManagerView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void OnRegister() {
    Init();
  }

  private void Init() {
    view.Init();
    dispatcher.AddListener(GameEvent.OnPlayMusic, OnPlayMusic);
    dispatcher.AddListener(GameEvent.OnStopMusic, OnStopMusic);
    dispatcher.AddListener(GameEvent.SetMusicLoop, OnSetMusicLoop);
  }

  private void OnSetMusicLoop(IEvent payload) {
    view.SetLoop(gameStateData.isLoop);
  }

  public void OnPlayMusic(IEvent payload) {
    view.Play();
  }

  private void OnStopMusic(IEvent payload) {
    view.Stop();
  }
}