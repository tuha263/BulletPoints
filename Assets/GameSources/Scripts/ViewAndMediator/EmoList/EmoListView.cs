using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class EmoListView : View {
  [SerializeField]
  private ScrollRect scroller;

  [SerializeField]
  private GameObject contentRoot;

  [SerializeField]
  private GameObject emoTile;

  public EmoTileView PopulateEmo(Sprite sprite) {
    EmoTileView emoTileView = contentRoot.InstantiateAsChild(emoTile).GetComponent<EmoTileView>();
    emoTileView.Init(sprite);
    emoTileView.gameObject.name = sprite.name;
    return emoTileView;
  }
}