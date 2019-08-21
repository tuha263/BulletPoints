using System;
using System.Collections.Generic;
using System.Linq;
using EnhancedUI.EnhancedScroller;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEditor;
using UnityEngine;

public class LoadDataMediator : EventMediator, IEnhancedScrollerDelegate
{
    [Inject] public LoadDataView view { get; set; }
    [Inject] public IGameStateData gameStateData { get; set; }
    [Inject] public LoadRecordSignal loadRecordSignal { get; set; }

    private string _saveName;
    private List<SaveItemModel> loadList = new List<SaveItemModel>();
    private List<SaveItemView> savedItemList;

    public override void OnRegister()
    {
        view.Init(OnLoad, OnClose, OnDelete, this);
        dispatcher.AddListener(GameEvent.OpenLoadGame, OnOpen);
        dispatcher.AddListener(GameEvent.OnChooseSaveData, OnChooseSaveName);
        OnClose();
    }


    private void OnChooseSaveName(IEvent payload)
    {
        _saveName = (string) payload.data;
    }

    private void OnOpen()
    {
        loadList.Clear();
        List<string> stringList = PersistDataHelper.GetLoadList();
        stringList.ForEach(name => loadList.Add(new SaveItemModel(name)));
        view.OnOpen(loadList);
    }

    public void OnClose()
    {
        view.OnClose();
    }

    public void OnLoad()
    {
        view.OnClose();
        List<string> loadGameData = PersistDataHelper.LoadData(_saveName);
        List<List<int>> listEmoData = loadGameData.Select(column =>
        {
            column = column.Remove(0, 1);
            return column.Split(',').Select(int.Parse).ToList();
        }).ToList();
        loadRecordSignal.Dispatch(listEmoData);
    }

    private void OnDelete()
    {
        PersistDataHelper.DeleteData(_saveName);
        loadList.Remove(loadList.Single(data => data.name.Equals(_saveName)));
        view.reLoadScroller();
    }


    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return loadList.Count;
    }

    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 50;
    }

    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        EnhancedScrollerCellView cellView = scroller.GetCellView(view.getSaveItemPrefab());
        cellView.SetData(loadList[dataIndex]);
        return cellView;
    }
}