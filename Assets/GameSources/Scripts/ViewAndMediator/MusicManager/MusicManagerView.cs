using AudioHelm;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MusicManagerView : View
{
    [SerializeField] public Sequencer sequencer;
    [Inject] public IGameStateData gameStateData { get; set; }

    public void Init()
    {
        ClearSequencer();
    }

    public void ClearSequencer()
    {
        sequencer.Clear();
    }

    public void Play()
    {
        sequencer.ResetBeat();
    }

    public void Stop()
    {
        sequencer.ResetBeat();
    }

    public void SetLoop(bool isLoop)
    {
        sequencer.loop = isLoop;
    }

    public virtual void AddNote(int collum, int index, EmoTileData emoTileData)
    {
        sequencer.AddNote(
            emoTileData.note + gameStateData.currentClef.Noteshigh[NodeCollumTileData.AmountOfNode - 1 - index], collum,
            collum + emoTileData.data.Notelength, 1);
    }

    public virtual void RemoveNote(int collum, int index, EmoTileData emoTileData)
    {
        sequencer.RemoveNotesInRange(
            emoTileData.note + gameStateData.currentClef.Noteshigh[NodeCollumTileData.AmountOfNode - 1 - index], collum,
            collum + emoTileData.data.Notelength);
    }
}