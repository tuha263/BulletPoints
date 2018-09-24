using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;
using UnityEngine.Audio;

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
    go.AddComponent<AudioHelm.AudioHelmClock>();
  }
}