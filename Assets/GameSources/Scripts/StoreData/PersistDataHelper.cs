using System;
using System.Collections.Generic;

public class PersistDataHelper
{
    private const String LIST_SAVE_FILE = "ListSaveFile";

    public static void SaveData(String dataName, GameStateData gameStateData)
    {
        ES2.Save(gameStateData, dataName);
        if (!GetLoadList().Contains(dataName))
        {
            UpdateLoadList(dataName, true);
        }
    }

    public static List<String> GetLoadList()
    {
        if (ES2.Exists(LIST_SAVE_FILE))
        {
            return ES2.LoadList<String>(LIST_SAVE_FILE);
        }

        return new List<string>();
    }

    private static void UpdateLoadList(String dataName, bool isAdd)
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

    public static GameStateData LoadData(String dataName)
    {
        return ES2.Load<GameStateData>(dataName);
    }

    public static void DeleteData(String dataName)
    {
        ES2.Delete(dataName);
        UpdateLoadList(dataName, false);
    }
}