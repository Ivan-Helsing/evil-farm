﻿using Entitas;

namespace Code.Gameplay.Common.Services
{
  public interface ICollisionRegistry
  {
    void Register(int instanceId, IEntity entity);
    void Unregister(int instanceId);
    TEntity Get<TEntity>(int instanceId) where TEntity : class;
  }
}