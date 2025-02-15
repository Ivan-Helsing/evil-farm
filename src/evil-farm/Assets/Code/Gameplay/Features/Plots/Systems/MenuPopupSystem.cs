using System.Collections.Generic;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.Plots.Systems
{
  public class MenuPopupSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _plots;
    private readonly List<GameEntity> _buffer = new (128);

    public MenuPopupSystem(GameContext game)
    {
      _plots = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Plot,
          GameMatcher.Arable,
          GameMatcher.Interacted,
          GameMatcher.InteractionProvider)
        .NoneOf(GameMatcher.MenuId));
    }

    public void Execute()
    {
      foreach (GameEntity plot in _plots.GetEntities(_buffer))
      {
        GameEntity window = plot.InteractionProvider.Interact(plot.WindowId);
        window.AddWorldPosition(plot.Transform.position.AddY());
        window.AddParentId(plot.Id);
        
        plot.AddMenuId(window.Id);
        plot.isInteracted = false;
      }
    }
  }
}