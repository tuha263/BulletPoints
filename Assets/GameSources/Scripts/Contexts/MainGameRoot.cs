using AudioHelm;
using strange.extensions.context.impl;
using UnityEngine;

public partial class MainGameRoot : ContextView {

  [SerializeField]
  private GameObject instanceGameObject;

  void Awake() {
    MainGameContext mainGameContext = new MainGameContext(this, true);
    context = mainGameContext;
    context.Start();
  }

  void Start(){
    instanceGameObject.gameObject.SetActive(true);
    AddClock();
  }

  void AddClock() {
    GameObject go = new GameObject();
    go.transform.parent = gameObject.transform;
    go.name = "HelmClock";
    go.AddComponent<AudioHelmClock>();
  }
}