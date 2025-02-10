using System.Collections.Generic;
using Code.Infrastructure.Entities.View.Factory;
using Entitas;

namespace Code.Infrastructure.Entities.View.Systems
{
  public class BindEntityViewFromPathWithParentSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly IEntityViewFactory _entityFactory;
    private readonly List<GameEntity> _buffer = new (64);

    public BindEntityViewFromPathWithParentSystem(GameContext game, IEntityViewFactory entityFactory)
    {
      _entityFactory = entityFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ViewPath,
          GameMatcher.Parent,
          GameMatcher.WorldPosition)
        .NoneOf(GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        _entityFactory.CreateViewForEntityWithParent(entity, entity.WorldPosition, entity.Parent);
      }
    }
  }
}