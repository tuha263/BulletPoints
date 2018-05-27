using strange.extensions.command.impl;

public class SetEmoCommand : Command {
  [Inject]
  public NodeCollumTileView nodeCollumTileView { get; set; }

  [Inject]
  public int nodeIndex { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  public override void Execute() {
    if (gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] != gameStateData.currentEmo) {
      gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] = gameStateData.currentEmo;
    } else {
      gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex] = null;
    }
    nodeCollumTileView.SetNodeData(nodeIndex, gameStateData.collumDatas[nodeCollumTileView.dataIndex - 1].emoDatas[nodeIndex]);
  }
}