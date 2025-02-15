using System.Collections.Generic;
using Code.Gameplay.Common.Services.Time;
using Entitas;

namespace Code.Gameplay.Features.Plots.Systems
{
  public class CropGrowingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _plots;
    private readonly List<GameEntity> _buffer = new (64);
    private readonly ITimeService _time;

    public CropGrowingSystem(GameContext game, ITimeService time)
    {
      _time = time;
      _plots = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Plot,
          GameMatcher.Sowed,
          GameMatcher.GrowPlant,
          GameMatcher.GrowingTimer,
          GameMatcher.GrowingDuration));
    }

    public void Execute()
    {
      foreach (GameEntity plot in _plots.GetEntities(_buffer))
      {
        plot.ReplaceGrowingTimer(plot.GrowingTimer - _time.DeltaTime);

        if (plot.GrowingTimer <= 0)
        {
          plot.RemoveGrowingTimer();
          plot.RemoveGrowingDuration();
          plot.RemoveGrowPlant();
          plot.isReadyToHarvest = true;
        }
      }
    }
  }
}