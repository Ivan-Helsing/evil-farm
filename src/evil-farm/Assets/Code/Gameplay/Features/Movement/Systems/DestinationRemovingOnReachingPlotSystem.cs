using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class DestinationRemovingOnReachingPlotSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _farmers;
    private readonly List<GameEntity> _buffer = new(1);

    public DestinationRemovingOnReachingPlotSystem(GameContext game)
    {
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Farmer,
          GameMatcher.DestinationPoint,
          GameMatcher.DestinationRadius,
          GameMatcher.MovingToSowThePlot));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers.GetEntities(_buffer))
      {
        if (ReachedDestination(farmer))
        {
          farmer.isSowing = true;
          farmer.isChangingAnimationState = true;
          farmer.isPerformingAction = true;
          
          farmer.isMoving = false;
          farmer.isMovingToSowThePlot = false;
          farmer.RemoveDestinationPoint();
        }
      }
    }

    private bool ReachedDestination(GameEntity entity)
    {
      var farmerPosition = new Vector2(entity.Transform.position.x, entity.Transform.position.z);
      var destinationPoint = new Vector2(entity.DestinationPoint.x, entity.DestinationPoint.z);
      
      return Vector2.Distance(farmerPosition, destinationPoint) < entity.DestinationRadius;
    }
  }
}