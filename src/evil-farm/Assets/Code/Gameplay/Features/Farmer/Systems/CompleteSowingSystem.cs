using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Farmer.Systems
{
  public class CompleteSowingSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _farmers;
    private readonly List<GameEntity> _buffer = new (4);

    public CompleteSowingSystem(GameContext game)
    {
      _game = game;
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Farmer,
          GameMatcher.Sowing,
          GameMatcher.TargetId,
          GameMatcher.CompletedAction));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers.GetEntities(_buffer))
      {
        GameEntity plot = _game.GetEntityWithId(farmer.TargetId);
        plot.isSowed = true;
        
        farmer.isSowing = false;
        farmer.isCompletedAction = false;
      }
    }
  }
}