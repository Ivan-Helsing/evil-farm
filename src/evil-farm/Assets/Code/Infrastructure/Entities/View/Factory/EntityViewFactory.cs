using Code.Infrastructure.Services.AssetProviding;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Entities.View.Factory
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private readonly IAssetProvider _assets;
    private readonly IInstantiator _instantiator;

    public EntityViewFactory(IAssetProvider assets, IInstantiator instantiator)
    {
      _assets = assets;
      _instantiator = instantiator;
    }

    public EntityBehaviour CreateViewForEntity(GameEntity entity, Vector3 at)
    {
      EntityBehaviour viewPrefab = _assets.LoadAsset<EntityBehaviour>(entity.ViewPath);
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        viewPrefab,
        position: at,
        rotation: Quaternion.identity,
        parentTransform: null);
      
      view.SetEntity(entity);
      
      return view;
    }
    
    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity, Vector3 at)
    {
      EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
        entity.ViewPrefab,
        position: at,
        rotation: Quaternion.identity,
        parentTransform: null);
      
      view.SetEntity(entity);
      view.Entity.Transform.position = view.Entity.WorldPosition;
      
      return view;
    }
  }
}