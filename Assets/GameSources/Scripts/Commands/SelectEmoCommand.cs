using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class SelectEmoCommand : Command {

  [Inject]
  public EmoTileData emoTileData { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public CurrentEmoMediator currentEmoMediator { get; set; }

  [Inject]
  public GlobalCoroutine globalCoroutine { get; set; }

  override public void Execute() {
    gameStateData.currentEmo = emoTileData;
    currentEmoMediator.view.Init(emoTileData);
    globalCoroutine.StartCoroutine(SampleEmoSound());
    Retain();
  }

  IEnumerator SampleEmoSound() {
    int note = emoTileData.data.Note + 12;
    emoTileData.sequencer.NoteOn(note);
    yield return new WaitForSeconds(0.3f);
    emoTileData.sequencer.NoteOff(note);
    Release();
  }
}