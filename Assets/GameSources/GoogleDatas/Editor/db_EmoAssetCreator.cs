using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/db_Emo")]
    public static void Createdb_EmoAssetFile()
    {
        db_Emo asset = CustomAssetUtility.CreateAsset<db_Emo>();
        asset.SheetName = "BulletPoints";
        asset.WorksheetName = "db_Emo";
        EditorUtility.SetDirty(asset);        
    }
    
}