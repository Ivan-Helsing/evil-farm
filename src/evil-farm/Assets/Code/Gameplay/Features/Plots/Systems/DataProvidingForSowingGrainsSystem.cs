using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Plots.Systems
{
  public class DataProvidingForSowingGrainsSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _plantMenu;
    private readonly List<GameEntity> _buffer = new (64);

    public DataProvidingForSowingGrainsSystem(GameContext game)
    {
      _game = game;
      _plantMenu = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.ParentId,
          GameMatcher.GrowPlant,
          GameMatcher.PlantWindow,
          GameMatcher.GrowingDuration));
    }

    public void Execute()
    {
      foreach (GameEntity menu in _plantMenu.GetEntities(_buffer))
      {
        
        
        // send farmer to the plot for sow the grains.  Use TargetId to approach to the particular plot.
        // after farmer approach to the plot, make an animation for sowing, like cast spell.
        // then provide all beneath data to plot and window.
        
        GameEntity plot = _game.GetEntityWithId(menu.ParentId);

        plot.AddGrowPlant(menu.GrowPlant);
        plot.AddGrowingDuration(menu.GrowingDuration);
        plot.AddGrowingTimer(menu.GrowingDuration);
        plot.isReadyToAppointDestination = true;
        
        if(plot.hasMenuId)
          plot.RemoveMenuId();

        plot.isArable = false;
        menu.isDestructed = true;
      }
    }
  }
}