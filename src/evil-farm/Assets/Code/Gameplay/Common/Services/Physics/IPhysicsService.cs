﻿using Code.Gameplay.Common.Services.Collisions;
using UnityEngine;

namespace Code.Gameplay.Common.Services.Physics
{
  public interface IPhysicsService
  {
    Vector3 RaycastHit(Vector2 from, float distance = 30f, CollisionLayer layer = CollisionLayer.Walkable);
  }
}