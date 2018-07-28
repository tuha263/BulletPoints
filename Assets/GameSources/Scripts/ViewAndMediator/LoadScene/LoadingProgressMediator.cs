using System.Collections;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingProgressMediator : Mediator {
  [Inject]
  public LoadingProgressView view { get; set; }

  [Inject]
  public IGameStateData gameStateData { get; set; }

  [Inject]
  public IClefsDataManager clefDataManager { get; set; }

  [Inject]
  public ITimeSigsDataManager timeSigsDataManager { get; set; }

  public override void OnRegister() {
    gameStateData.currentTimeSig = timeSigsDataManager.Datas.Find(timeSig => timeSig.TIMESIGSTYPE == TimeSigsType._4_4);
    gameStateData.currentClef = clefDataManager.Datas.Find(clef => clef.CLEFSTYPE == ClefsType.Major);

    LoadMainGameScene();
  }

  private void LoadMainGameScene() {
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
    DontDestroyOnLoad(gameObject);

    view.loadSceneSlider.value = 0;
    DOTween.To(() => view.loadSceneSlider.value, x => view.loadSceneSlider.value = x, 1, 2).OnComplete(
      () => {
        transform.parent.gameObject.SetActive(false);
      }
    );
  }

  IEnumerator LoadYourAsyncScene(AsyncOperation asyncLoad) {

    // The Application loads the Scene in the background as the current Scene runs.
    // This is particularly good for creating loading screens.
    // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
    // a sceneBuildIndex of 1 as shown in Build Settings.

    // Wait until the asynchronous scene fully loads
    while (!asyncLoad.isDone) {
      yield return null;
    }
  }
}