using UnityEngine;

namespace Code.Infrastructure.Entities.View.Factory
{
  public interface IEntityViewFactory
  {
    EntityBehaviour CreateViewForEntity(GameEntity entity, Vector3 at);
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity, Vector3 at);
  }
}