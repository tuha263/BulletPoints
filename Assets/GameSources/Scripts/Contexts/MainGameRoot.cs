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
  }
}