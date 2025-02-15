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
          farmer.isPerformingSow = true;
          
          farmer.isMoving = false;
          farmer.isMovingToSowThePlot = false;
          farmer.RemoveDestinationPoint();
        }
      }
    }

    private bool ReachedDestination(GameEntity farmer) =>
      Vector3.Distance(farmer.Transform.position, farmer.DestinationPoint) < farmer.DestinationRadius;
  }
}