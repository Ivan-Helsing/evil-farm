using Code.Infrastructure.Entities.View.Factory;
using Entitas;

namespace Code.Infrastructure.Entities.View.Systems
{
  public class BindEntityViewFromPrefabSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly IEntityViewFactory _entityFactory;

    public BindEntityViewFromPrefabSystem(GameContext game, IEntityViewFactory entityFactory)
    {
      _entityFactory = entityFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ViewPath,
          GameMatcher.WorldPosition)
        .NoneOf(GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        _entityFactory.CreateViewForEntityFromPrefab(entity, entity.WorldPosition);
      }
    }
  }
}