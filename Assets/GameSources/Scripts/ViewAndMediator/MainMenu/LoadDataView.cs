using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadDataView : View
{
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button _cancelButotn;
    [SerializeField] private SaveItemView saveItemPrefab;
    [SerializeField] private EnhancedScroller scroller;

    private List<SaveItemView> loadList;
    public void Init(UnityAction loadAction, UnityAction cancelAction, UnityAction deleteAction,IEnhancedScrollerDelegate scrollerDelegate)
    {
        _loadButton.onClick.AddListener(loadAction);
        _cancelButotn.onClick.AddListener(cancelAction);
        deleteButton.onClick.AddListener(deleteAction);
        scroller.Delegate = scrollerDelegate;
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }

    public void OnOpen(List<SaveItemModel> loadList)
    {
        gameObject.SetActive(true);
        reLoadScroller();
    }

    public SaveItemView getSaveItemPrefab()
    {
        return saveItemPrefab;
    }

    public void reLoadScroller()
    {
        scroller.ReloadData();
    }
}