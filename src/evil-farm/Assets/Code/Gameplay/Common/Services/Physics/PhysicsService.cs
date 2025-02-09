using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Collisions;
using Code.Gameplay.Features.Cameras.Provider;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Physics
{
  public class PhysicsService : IPhysicsService
  {
    public Vector3 RaycastHit(Vector2 from, Camera with, float distance = 30f, CollisionLayer layer = CollisionLayer.Walkable)
    {
      Ray ray = with.ScreenPointToRay(from);
      if (UnityEngine.Physics.Raycast(ray, out RaycastHit hit, distance, layer.AsLayer()))
      {
        return hit.point;
      }
      return Vector3.zero;
    }
  }
}