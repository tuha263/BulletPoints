using System;
using System.Collections.Generic;

public class PersistDataHelper
{
    private const string LIST_SAVE_FILE = "ListSaveFile";

    public static void SaveData(string dataName, GameStateData gameStateData)
    {
        ES2.Save(gameStateData, dataName);
        if (!GetLoadList().Contains(dataName))
        {
            UpdateLoadList(dataName, true);
        }
    }

    public static List<string> GetLoadList()
    {
        if (ES2.Exists(LIST_SAVE_FILE))
        {
            return ES2.LoadList<string>(LIST_SAVE_FILE);
        }

        return new List<string>();
    }

    private static void UpdateLoadList(string dataName, bool isAdd)
    {
        var loadList = GetLoadList();
        if (isAdd)
        {
            loadList.Add(dataName);
        }
        else
        {
            loadList.Remove(dataName);
        }

        ES2.Save(loadList, LIST_SAVE_FILE);
    }

    public static GameStateData LoadData(string dataName)
    {
        return ES2.Load<GameStateData>(dataName);
    }

    public static void DeleteData(string dataName)
    {
        ES2.Delete(dataName);
        UpdateLoadList(dataName, false);
    }
}