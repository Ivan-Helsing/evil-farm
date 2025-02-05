using System;
using System.Collections;
using Code.Infrastructure.Services.Coroutines;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Services.Scenes
{
  public class SceneLoader : ISceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) => 
      _coroutineRunner = coroutineRunner;

    public void LoadScene(string sceneName, Action onLoaded = null) => 
      _coroutineRunner.StartCoroutine(Load(sceneName, onLoaded));

    private IEnumerator Load(string nextScene, Action onLoaded = null)
    {
      if (SceneManager.GetActiveScene().name == nextScene)
      {
        onLoaded?.Invoke();
        yield break;
      }
      
      AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

      while (!waitNextScene.isDone)
        yield return null;
      
      onLoaded?.Invoke();
    }
  }
}