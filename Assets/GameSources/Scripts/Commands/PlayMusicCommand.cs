using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AudioHelm;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;
using UnityEngine.Audio;

public class PlayMusicCommand : Command
{
    private const int DEFAULT_SPEED = 60;

    [Inject] public IGameStateData gameStateData { get; set; }

    [Inject] public Dictionary<AudioMixerGroup, MusicManagerView> musicManagerViewDic { get; set; }

    [Inject] public MusicFieldMediator musicFieldMediator { get; set; }

    [Inject] public AudioHelmClock helmClock { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    [Inject] public GlobalCoroutine globalCoroutine { get; set; }

    public override void Execute()
    {
        dispatcher.Dispatch(GameEvent.OnStartCount);
        globalCoroutine.StartCoroutine(ExecuteRoutine());
        Retain();
    }

    private IEnumerator ExecuteRoutine()
    {
        int timeRemain = gameStateData.currentTimeSig.Count;
        dispatcher.Dispatch(GameEvent.OnCount, timeRemain);
        while (timeRemain >= 1)
        {
            yield return new WaitForSeconds(DEFAULT_SPEED / gameStateData.musicSpeed);
            timeRemain--;
            dispatcher.Dispatch(GameEvent.OnCount, timeRemain);
        }

        gameStateData.isPlaying = true;
        helmClock.pause = false;
        gameStateData.gameState = GameState.Play;
        musicFieldMediator.MoveMusicStaff(0);
        musicFieldMediator.RemoveEmptyCell();
        foreach (var sequencer in musicManagerViewDic)
        {
            sequencer.Value.sequencer.length = musicFieldMediator.GetStaffLength();
        }

        musicManagerViewDic.Values.ToList().ForEach(musicManagerView => { musicManagerView.ClearSequencer(); });
        for (int i = 0; i < gameStateData.collumDatas.Count; i++)
        {
            for (int j = 0; j < gameStateData.collumDatas[i].emoDatas.Count; j++)
            {
                EmoTileData emoTileData = gameStateData.collumDatas[i].emoDatas[j];
                if (emoTileData == null)
                {
                    continue;
                }

                musicManagerViewDic[emoTileData.audioMixerGroup].AddNote(i, j, emoTileData);
            }
        }

        dispatcher.Dispatch(GameEvent.OnPlayMusic);
        Release();
    }
}