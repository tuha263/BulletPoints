using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class db_ClefsData
{
  [SerializeField]
  ClefsType clefstype;
  public ClefsType CLEFSTYPE { get {return clefstype; } set { clefstype = value;} }
  
  [SerializeField]
  string texture;
  public string Texture { get {return texture; } set { texture = value;} }
  
  [SerializeField]
  int[] noteshigh = new int[0];
  public int[] Noteshigh { get {return noteshigh; } set { noteshigh = value;} }
  
}