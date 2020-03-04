using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EmoTileView : EnhancedScrollerCellView
{
    [SerializeField] private Image icon;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedBackGround;

    private EmoTileData data;

    public void Init(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public override void SetData(EnhancedScrollerCellData data)
    {
        this.data = data as EmoTileData;
        Init(this.data.sprite);
    }

    public EmoTileData GetData()
    {
        return data;
    }

    public void SetOnClickListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }
}