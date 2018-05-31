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
[CustomEditor(typeof(db_StaffSetting))]
public class db_StaffSettingEditor : BaseGoogleEditor<db_StaffSetting>
{	    
    public override bool Load()
    {        
        db_StaffSetting targetData = target as db_StaffSetting;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_StaffSettingData>(targetData.WorksheetName) ?? db.CreateTable<db_StaffSettingData>(targetData.WorksheetName);
        
        List<db_StaffSettingData> myDataList = new List<db_StaffSettingData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_StaffSettingData data = new db_StaffSettingData();
            
            data = Cloner.DeepCopy<db_StaffSettingData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
    public static void ReLoad()
    {        
        db_StaffSetting targetData = Resources.Load<db_StaffSetting>("GoogleDatas/db_StaffSetting");
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_StaffSettingData>(targetData.WorksheetName) ?? db.CreateTable<db_StaffSettingData>(targetData.WorksheetName);
        
        List<db_StaffSettingData> myDataList = new List<db_StaffSettingData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_StaffSettingData data = new db_StaffSettingData();
            
            data = Cloner.DeepCopy<db_StaffSettingData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
    }
}
