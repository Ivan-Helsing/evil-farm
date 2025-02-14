using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Plots.Systems
{
  public class PlotInteractionCleanupSystem : ICleanupSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _plots;
    private readonly List<GameEntity> _buffer = new(64);

    public PlotInteractionCleanupSystem(GameContext game)
    {
      _game = game;
      _plots = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Plot,
          GameMatcher.ReadyToCleanup));
    }

    public void Cleanup()
    {
      foreach (GameEntity plot in _plots.GetEntities(_buffer))
      {
        GameEntity window = _game.GetEntityWithId(plot.MenuId);
        window.isDestructed = true;
        
        plot.RemoveMenuId();
        plot.isReadyToCleanup = false;
      }
    }
  }
}