using UnityEngine;

namespace Code.Infrastructure.Services.AssetProviding
{
  public interface IAssetProvider
  {
    T LoadAsset<T>(string path) where T : Component;
    GameObject Load(string path);
  }
}