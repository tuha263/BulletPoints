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
[CustomEditor(typeof(db_Emo))]
public class db_EmoEditor : BaseGoogleEditor<db_Emo>
{	    
    public override bool Load()
    {        
        db_Emo targetData = target as db_Emo;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<db_EmoData>(targetData.WorksheetName) ?? db.CreateTable<db_EmoData>(targetData.WorksheetName);
        
        List<db_EmoData> myDataList = new List<db_EmoData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            db_EmoData data = new db_EmoData();
            
            data = Cloner.DeepCopy<db_EmoData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
