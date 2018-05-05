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
    dispatcher.AddListener(GameEvent.OnPlayOrStopMusic, OnPlayOrStopMusic);
    dispatcher.AddListener(GameEvent.SetMusicLoop, OnSetMusicLoop);
    gameStateData.musicLength = view.GetMusicLength();
    gameStateData.division = view.GetMusicDivision();
    dispatcher.Dispatch(GameEvent.OnInitStaff);
  }

  private void OnSetMusicLoop(IEvent payload) {
    view.SetLoop(gameStateData.isLoop);
  }

  private void OnPlayOrStopMusic(IEvent payload) {
    if (gameStateData.isPlaying) {
      OnPlayMusic();
      return;
    }
    OnStopMusic();
  }

  public void OnPlayMusic() {
    view.ClearSequencer();
    for (int i = 0; i < gameStateData.collumDatas.Count; i++) {
      NodeCollumTileData nodeCollumTileData = gameStateData.collumDatas[i];
      for (int j = 0; j < nodeCollumTileData.emoDatas.Count; j++) {
        EmoTileData emoTileData = nodeCollumTileData.emoDatas[j];
        if (emoTileData == null) {
          continue;
        }
        view.AddNode(i, nodeCollumTileData.emoDatas.Count - j - 1, emoTileData);
      }
    }
    view.Play();
  }

  private void OnStopMusic() {
    view.Stop();
  }
}