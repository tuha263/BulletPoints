using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/db_TimeSigs")]
    public static void Createdb_TimeSigsAssetFile()
    {
        db_TimeSigs asset = CustomAssetUtility.CreateAsset<db_TimeSigs>();
        asset.SheetName = "BulletPoints";
        asset.WorksheetName = "db_TimeSigs";
        EditorUtility.SetDirty(asset);        
    }
    
}