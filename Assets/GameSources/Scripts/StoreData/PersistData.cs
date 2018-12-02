using System;
using System.Collections.Generic;

public class PersistData
{
    public static void SaveData(String dataName, GameStateData gameStateData)
    {
        ES2.Save(gameStateData, dataName);
    }

    public static GameStateData LoadData(String dataName)
    {
        return ES2.Load<GameStateData>(dataName);
    }

    public static void DeleteData(String dataName)
    {
        ES2.Delete(dataName);
    }

    public static List<String> GetListStoreData()
    {
        throw new NotImplementedException();
    }
}