using Code.Gameplay.Common.Services.Collisions;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Physics
{
  public interface IPhysicsService
  {
    Vector3 RaycastHitPosition(Vector2 origin, Camera with, float distance = 30f, CollisionLayer layer = CollisionLayer.Walkable);
    Vector3 Gravity { get; }
    GameEntity RaycastHitEntity(Vector2 origin, Camera with, float maxDistance = 30f, CollisionLayer layer = CollisionLayer.Interactable);
  }
}