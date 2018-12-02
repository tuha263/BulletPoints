using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadDataView : View
{
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _cancelButotn;
    [SerializeField] private GameObject _saveItemPrefab;
    [SerializeField] private GameObject _saveItemsContainer;
    [SerializeField] private List<SaveItemView> listItem;

    public void Init(UnityAction loadButton, UnityAction cancelButton)
    {
        _loadButton.onClick.AddListener(loadButton);
        _cancelButotn.onClick.AddListener(cancelButton);
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnOpen()
    {
        gameObject.SetActive(true);
        var loadList = PersistDataHelper.GetLoadList();
        for (int i = 0; i < loadList.Count; i++)
        {
            listItem[i].SetData(loadList[i]);
        }
    }
}