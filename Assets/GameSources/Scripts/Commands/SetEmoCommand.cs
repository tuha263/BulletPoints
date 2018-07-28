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

    public override void Execute()
    {
        //dataIndex - 1 because of melody data    
        if (gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] != gameStateData.currentEmo)
        {
            gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] = gameStateData.currentEmo;
            //Sound note when set
            if (!gameStateData.isPlaying)
            {
                var note = gameStateData.currentEmo.note +
                           gameStateData.currentClef.Noteshigh[NodeCollumTileData.AmountOfNode - 1 - nodeIndex];
                gameStateData.currentEmo.sequencer.NoteOn(note);
                globalCoroutine.StartCoroutine(OffNote(note, gameStateData.currentEmo.sequencer));
            }
        }
        else
        {
            gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] = null;
        }

        nodeCollumTileView.SetNodeData(nodeIndex,
            gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex]);
        nodeCollumTileView.DoMoveNote(nodeIndex);

        //Set note when playing
        if (gameStateData.isPlaying)
        {
            musicManagerViewDic[gameStateData.currentEmo.audioMixerGroup].AddNode(nodeCollumTileView.dataIndex - 1,
                nodeIndex, gameStateData.currentEmo);
        }
    }

    private IEnumerator OffNote(int note, Sequencer sequencer)
    {
        yield return new WaitForSeconds(0.3f);
        sequencer.NoteOff(note);
    }
}