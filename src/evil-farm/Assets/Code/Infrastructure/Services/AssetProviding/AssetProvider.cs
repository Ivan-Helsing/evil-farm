using UnityEngine;

namespace Code.Infrastructure.Services.AssetProviding
{
  public class AssetProvider : IAssetProvider
  {
    public T LoadAsset<T>(string path) where T : Component => 
      Resources.Load<T>(path);

    public GameObject Load(string path) => 
      Resources.Load<GameObject>(path);
  }
}