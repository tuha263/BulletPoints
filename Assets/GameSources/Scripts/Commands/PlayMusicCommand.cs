using System.Collections.Generic;
using System.Linq;
using AudioHelm;
using strange.extensions.command.impl;
using UnityEngine.Audio;

public class PlayMusicCommand : Command {
  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public Dictionary<AudioMixerGroup, MusicManagerView> musicManagerViewDic { get; set; }

  [Inject]
  public MusicFieldMediator musicFieldMediator { get; set; }

  public override void Execute() {
    gameStateData.gameState = GameState.Play;
    musicFieldMediator.MoveMusicStaff(0);
    musicFieldMediator.RemoveEmptyCell();
    foreach (var sequencer in musicManagerViewDic) {
      sequencer.Value.sequencer.length = musicFieldMediator.GetStaffLength();
    }

    musicManagerViewDic.Values.ToList().ForEach(musicManagerView => {
      musicManagerView.ClearSequencer();
    });
    for (int i = 0; i < gameStateData.collumDatas.Count; i++) {
      for (int j = 0; j < gameStateData.collumDatas[i].emoDatas.Count; j++) {
        EmoTileData emoTileData = gameStateData.collumDatas[i].emoDatas[j];
        if (emoTileData == null) {
          continue;
        }
        musicManagerViewDic[emoTileData.audioMixerGroup].AddNode(i, j, emoTileData);
      }
    }
  }
}