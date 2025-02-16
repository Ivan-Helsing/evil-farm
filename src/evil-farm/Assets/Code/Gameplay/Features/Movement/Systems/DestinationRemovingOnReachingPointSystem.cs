using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class DestinationRemovingOnReachingPointSystem : IExecuteSystem
  {
    private const float Epsilon = 0.05f;
    
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new (32);

    public DestinationRemovingOnReachingPointSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Transform,
          GameMatcher.DestinationPoint)
        .NoneOf(GameMatcher.MovingToSowThePlot));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (ReachedDestination(entity))
        {
          entity.isChangingAnimationState = true;
          
          entity.isMoving = false;
          entity.RemoveDestinationPoint();
        }
      }
    }

    private bool ReachedDestination(GameEntity entity)
    {
      var farmerPosition = new Vector2(entity.Transform.position.x, entity.Transform.position.z);
      var destinationPoint = new Vector2(entity.DestinationPoint.x, entity.DestinationPoint.z);
      
      return Vector2.Distance(farmerPosition, destinationPoint) < Epsilon;
    }
  }
}