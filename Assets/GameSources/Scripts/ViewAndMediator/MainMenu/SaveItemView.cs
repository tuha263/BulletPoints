using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveItemView : EnhancedScrollerCellView
{
    [SerializeField] private Button button;
    [SerializeField] private Text _saveNameText;

    public void Init(UnityAction onclick)
    {
        button.onClick.AddListener(onclick);
    }

    public string GetSaveName()
    {
        return _saveNameText.text;
    }

    public override void SetData(EnhancedScrollerCellData data)
    {
        _saveNameText.text = ((SaveItemModel) data).name;
    }
}