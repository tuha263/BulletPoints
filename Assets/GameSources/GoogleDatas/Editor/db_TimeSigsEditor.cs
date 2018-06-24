using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(db_TimeSigs))]
public class db_TimeSigsEditor : BaseGoogleEditor<db_TimeSigs>
{	    
    public override bool Load()
    {        
        db_TimeSigs targetData = target as db_TimeSigs;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_TimeSigsData>(targetData.WorksheetName) ?? db.CreateTable<db_TimeSigsData>(targetData.WorksheetName);
        
        List<db_TimeSigsData> myDataList = new List<db_TimeSigsData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_TimeSigsData data = new db_TimeSigsData();
            
            data = Cloner.DeepCopy<db_TimeSigsData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
    public static void ReLoad()
    {        
        db_TimeSigs targetData = Resources.Load<db_TimeSigs>("GoogleDatas/db_TimeSigs");
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_TimeSigsData>(targetData.WorksheetName) ?? db.CreateTable<db_TimeSigsData>(targetData.WorksheetName);
        
        List<db_TimeSigsData> myDataList = new List<db_TimeSigsData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_TimeSigsData data = new db_TimeSigsData();
            
            data = Cloner.DeepCopy<db_TimeSigsData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
    }
}
