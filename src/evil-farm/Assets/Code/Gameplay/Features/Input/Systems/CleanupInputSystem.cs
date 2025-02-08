using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class CleanupInputSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly List<GameEntity> _buffer = new(4);

    public CleanupInputSystem(GameContext game)
    {
      _inputs = game.GetGroup(GameMatcher
        .AllOf(
        GameMatcher.Input));
    }

    public void Cleanup()
    {
      foreach (GameEntity input in _inputs.GetEntities(_buffer))
      {
        input.isWalkingProvided = false;
        input.isInteracted = false;
        
        input.isReadyToCleanup = false;
      }
    }
  }
}