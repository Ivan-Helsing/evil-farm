using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class DestinationRemovingOnReachingPointSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _farmers;
    private const float Epsilon = 0.05f;

    public DestinationRemovingOnReachingPointSystem(GameContext game)
    {
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Farmer,
          GameMatcher.DestinationPoint)
        .NoneOf(GameMatcher.MovingToSowThePlot));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers)
      {
        if (ReachedDestination(farmer))
        {
          farmer.isMoving = false;
          farmer.RemoveDestinationPoint();
        }
      }
    }

    private bool ReachedDestination(GameEntity farmer) => 
      Vector3.Distance(farmer.Transform.position, farmer.DestinationPoint) < Epsilon;
  }
}