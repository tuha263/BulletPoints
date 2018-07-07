using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class db_TimeSigsData
{
  [SerializeField]
  TimeSigsType timesigstype;
  public TimeSigsType TIMESIGSTYPE { get {return timesigstype; } set { timesigstype = value;} }
  
  [SerializeField]
  string texture;
  public string Texture { get {return texture; } set { texture = value;} }
  
  [SerializeField]
  int sequencemeasurelength;
  public int Sequencemeasurelength { get {return sequencemeasurelength; } set { sequencemeasurelength = value;} }
  
  [SerializeField]
  string[] divisonlist = new string[0];
  public string[] Divisonlist { get {return divisonlist; } set { divisonlist = value;} }
  
  [SerializeField]
  int[] beatlength = new int[0];
  public int[] Beatlength { get {return beatlength; } set { beatlength = value;} }
  
}