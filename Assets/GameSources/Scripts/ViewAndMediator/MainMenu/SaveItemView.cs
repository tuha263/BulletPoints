using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveItemView : View
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

    public void SetData(string value)
    {
        _saveNameText.text = value;
    }
}