using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using System.Collections;

public class SelectEmoCommand : Command {

  [Inject]
  public EmoTileData emoTileData { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public CurrentEmoMediator currentEmoMediator { get; set; }

  override public void Execute() {
    gameStateData.currentEmo = emoTileData;
    currentEmoMediator.view.Init(emoTileData);
    SampleEmoSound();
  }

  IEnumerator SampleEmoSound() {
    int note = emoTileData.data.Note + 12;
    emoTileData.sequencer.NoteOn(note);
    yield return new WaitForSeconds(0.5f);
    emoTileData.sequencer.NoteOff(note);
  }
}