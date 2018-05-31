using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/db_StaffSetting")]
    public static void Createdb_StaffSettingAssetFile()
    {
        db_StaffSetting asset = CustomAssetUtility.CreateAsset<db_StaffSetting>();
        asset.SheetName = "BulletPoints";
        asset.WorksheetName = "db_StaffSetting";
        EditorUtility.SetDirty(asset);        
    }
    
}