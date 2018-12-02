using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaveInputView : View
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private InputField _inputField;

    public void Init(UnityAction saveButtonAction, UnityAction cancelAction)
    {
        _saveButton.onClick.AddListener(saveButtonAction);
        _cancelButton.onClick.AddListener(cancelAction);
    }

    public string GetSaveName()
    {
        return _inputField.text;
    }

    public void OnOpen()
    {
        gameObject.SetActive(true);
        _inputField.text = "";
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
}