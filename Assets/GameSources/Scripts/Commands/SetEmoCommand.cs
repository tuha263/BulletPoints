using System.Collections;
using System.Collections.Generic;
using AudioHelm;
using DG.Tweening;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.Audio;

public class SetEmoCommand : Command
{
    [Inject] public NodeCollumTileView nodeCollumTileView { get; set; }

    [Inject] public int nodeIndex { get; set; }

    [Inject] public IGameStateData gameStateData { get; set; }

    [Inject] public Dictionary<AudioMixerGroup, MusicManagerView> musicManagerViewDic { get; set; }
    [Inject] public GlobalCoroutine globalCoroutine { get; set; }

    //dataIndex - 1 because of melody data    
    public override void Execute()
    {
        //remove note when playing
        if (gameStateData.isPlaying && getSettedEmoTileData() != null)
        {
            musicManagerViewDic[getSettedEmoTileData().audioMixerGroup].RemoveNote(nodeCollumTileView.dataIndex - 1,
                nodeIndex, getSettedEmoTileData());
        }

        if (getSettedEmoTileData() == null)
        {
            SetSettedEmoTiledData(gameStateData.currentEmo);
            //Sound note when set if is not playing
            if (!gameStateData.isPlaying)
            {
                int note;
                if (gameStateData.currentEmo.soundType == SoundType.Drum)
                {
                    note = gameStateData.currentEmo.note + (NodeCollumTileData.AmountOfNode - 1 - nodeIndex) / 3;
                }
                else
                {
                    note = gameStateData.currentEmo.note +
                           gameStateData.currentClef.Noteshigh[NodeCollumTileData.AmountOfNode - 1 - nodeIndex];
                }

                gameStateData.currentEmo.sequencer.NoteOn(note);
                globalCoroutine.StartCoroutine(OffNote(note, gameStateData.currentEmo.sequencer));
            }
        }
        else
        {
            SetSettedEmoTiledData(null);
        }

        nodeCollumTileView.SetNodeData(nodeIndex, getSettedEmoTileData());
        nodeCollumTileView.DoMoveNote(nodeIndex);


        //Set note when playing
        if (gameStateData.isPlaying && getSettedEmoTileData() != null)
        {
            musicManagerViewDic[gameStateData.currentEmo.audioMixerGroup].AddNote(nodeCollumTileView.dataIndex - 1,
                nodeIndex, getSettedEmoTileData());
        }
    }

    private EmoTileData getSettedEmoTileData()
    {
        return gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex];
    }

    private void SetSettedEmoTiledData(EmoTileData emoTileData)
    {
        gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] = emoTileData;
    }

    private IEnumerator OffNote(int note, Sequencer sequencer)
    {
        yield return new WaitForSeconds(0.3f);
        sequencer.NoteOff(note);
    }
}