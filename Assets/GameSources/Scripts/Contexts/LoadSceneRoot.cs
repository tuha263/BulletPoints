using System.Collections;
using DG.Tweening;
using strange.extensions.context.impl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneRoot : ContextView {
  private void Awake() {
    LoadSceneContext loadSceneContext = new LoadSceneContext(this, true);
    context = loadSceneContext;
    context.Start();

    DontDestroyOnLoad(gameObject);
  }
}