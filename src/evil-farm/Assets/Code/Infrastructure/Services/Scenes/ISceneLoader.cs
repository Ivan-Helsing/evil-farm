using System;

namespace Code.Infrastructure.Services.Scenes
{
  public interface ISceneLoader
  {
    void LoadScene(string sceneName, Action onLoaded = null);
  }
}