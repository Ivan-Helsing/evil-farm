using Code.Infrastructure.Services.AssetProviding;
using Zenject;

namespace Code.Infrastructure.Entities.Factory
{
  public class EcsFactory : IEcsFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assetProvider;

    public EcsFactory(IInstantiator instantiator, IAssetProvider assetProvider)
    {
      _instantiator = instantiator;
      _assetProvider = assetProvider;
    }

    public T CreateEcsRunner<T>() => 
      _instantiator.InstantiatePrefabForComponent<T>(_assetProvider.Load(AssetPath.EcsRunner));
  }
}