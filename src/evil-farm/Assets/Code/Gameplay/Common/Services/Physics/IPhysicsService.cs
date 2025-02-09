using Code.Gameplay.Common.Services.Collisions;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Physics
{
  public interface IPhysicsService
  {
    Vector3 RaycastHit(Vector2 from, Camera with, float distance = 30f, CollisionLayer layer = CollisionLayer.Walkable);
    Vector3 Gravity { get; }
  }
}