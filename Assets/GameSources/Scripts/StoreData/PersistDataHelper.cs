using System.Collections.Generic;
using System.Linq;

public class PersistDataHelper
{
    private const string ListSaveFile = "ListSaveFile";

    public static void SaveData(string dataName, GameStateData gameStateData)
    {
        int[][] saveData = gameStateData.collumDatas.Select(columnData => columnData.emoDatas)
            .Select(emoList => emoList.Select(emo => emo?.data.ID ?? 0))
            .Select(enumerable => enumerable.ToArray()).ToArray();

        ES2.Save(To2DArray(saveData), dataName);

        if (!GetLoadList().Contains(dataName))
        {
            UpdateLoadList(dataName, true);
        }
    }

    private static int[,] To2DArray(int[][] arr)
    {
        int numOfColumn = arr.Length;
        int numOfNote = arr[0].Length;
        
        var result = new int[numOfColumn, numOfNote];
        for (int i = 0; i < numOfColumn; i++)
        {
            for (int j = 0; j < numOfNote; j++)
            {
                result[i, j] = arr[i][j];
            }
        }

        return result;
    }

    public static List<string> GetLoadList()
    {
        return ES2.Exists(ListSaveFile) ? ES2.LoadList<string>(ListSaveFile) : new List<string>();
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

        ES2.Save(loadList, ListSaveFile);
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