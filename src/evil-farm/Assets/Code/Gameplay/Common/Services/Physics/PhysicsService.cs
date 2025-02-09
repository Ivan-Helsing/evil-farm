using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Collisions;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Physics
{
  public class PhysicsService : IPhysicsService
  {
    public Vector3 Gravity => UnityEngine.Physics.gravity;
    
    public Vector3 RaycastHit(Vector2 from, Camera with, float distance = 30f, CollisionLayer layer = CollisionLayer.Walkable)
    {
      Ray ray = with.ScreenPointToRay(from);
      if (UnityEngine.Physics.Raycast(ray, out RaycastHit hit, distance, layer.AsLayer()))
      {
        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        return hit.point;
      }
      return Vector3.zero;
    }
  }
}