using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Collisions;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Physics
{
  public class PhysicsService : IPhysicsService
  {
    private readonly ICollisionRegistry _collisions;

    public PhysicsService(ICollisionRegistry collisions) => 
      _collisions = collisions;

    public Vector3 Gravity => UnityEngine.Physics.gravity;
    
    public GameEntity RaycastHitEntity(Vector2 origin, Camera with, float maxDistance = 30f, CollisionLayer layer = CollisionLayer.Interactable)
    {
      Ray ray = with.ScreenPointToRay(origin);
      
      return UnityEngine.Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer.AsLayer()) 
        ? _collisions.Get<GameEntity>(hit.collider.GetInstanceID()) 
        : null;
    }

    public Vector3 RaycastHitPosition(Vector2 origin, Camera with, float distance = 30f, CollisionLayer layer = CollisionLayer.Walkable)
    {
      Ray ray = with.ScreenPointToRay(origin);
      if (UnityEngine.Physics.Raycast(ray, out RaycastHit hit, distance, layer.AsLayer()))
      {
        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        return hit.point;
      }
      return Vector3.zero;
    }
  }
}