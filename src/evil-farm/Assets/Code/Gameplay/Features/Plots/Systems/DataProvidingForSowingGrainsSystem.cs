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
        GameEntity plot = _game.GetEntityWithId(menu.ParentId);

        if(plot.hasGrowPlant)
          return;
        
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