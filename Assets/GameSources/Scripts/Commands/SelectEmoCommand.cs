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

  override public void Execute() {
    gameStateData.currentEmo = emoTileData;
    currentEmoMediator.view.Init(emoTileData);
  }
}