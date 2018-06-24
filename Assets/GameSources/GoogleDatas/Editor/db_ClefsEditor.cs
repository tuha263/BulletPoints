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
[CustomEditor(typeof(db_Clefs))]
public class db_ClefsEditor : BaseGoogleEditor<db_Clefs>
{	    
    public override bool Load()
    {        
        db_Clefs targetData = target as db_Clefs;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_ClefsData>(targetData.WorksheetName) ?? db.CreateTable<db_ClefsData>(targetData.WorksheetName);
        
        List<db_ClefsData> myDataList = new List<db_ClefsData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_ClefsData data = new db_ClefsData();
            
            data = Cloner.DeepCopy<db_ClefsData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
    public static void ReLoad()
    {        
        db_Clefs targetData = Resources.Load<db_Clefs>("GoogleDatas/db_Clefs");
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_ClefsData>(targetData.WorksheetName) ?? db.CreateTable<db_ClefsData>(targetData.WorksheetName);
        
        List<db_ClefsData> myDataList = new List<db_ClefsData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_ClefsData data = new db_ClefsData();
            
            data = Cloner.DeepCopy<db_ClefsData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
    }
}
