using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/db_Clefs")]
    public static void Createdb_ClefsAssetFile()
    {
        db_Clefs asset = CustomAssetUtility.CreateAsset<db_Clefs>();
        asset.SheetName = "BulletPoints";
        asset.WorksheetName = "db_Clefs";
        EditorUtility.SetDirty(asset);        
    }
    
}