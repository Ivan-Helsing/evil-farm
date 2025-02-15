using Code.Gameplay.Common.Services;
using Code.Infrastructure.Entities.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Entities.View
{
  public class EntityBehaviour : MonoBehaviour, IEntityView
  {
    private GameEntity _entity;
    public GameEntity Entity => _entity;

    private ICollisionRegistry _collisions;

    [Inject]
    public void Construct(ICollisionRegistry collisions) => 
      _collisions = collisions;

    public void SetEntity(GameEntity entity)
    {
      _entity = entity;
      _entity.AddView(this);
      _entity.Retain(this);

      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.RegisterComponents();

      foreach (Collider collider in GetComponentsInChildren<Collider>()) 
        _collisions.Register(collider.GetInstanceID(), _entity);
    }

    public void ReleaseEntity()
    {
      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.UnregisterComponents();
      
      foreach (Collider collider in GetComponentsInChildren<Collider>())
        _collisions.Unregister(collider.GetInstanceID());
      
      _entity.Release(this);
      _entity = null;
    }
  }
}