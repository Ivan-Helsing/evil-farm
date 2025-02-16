using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class WorldPositionUpdatingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public WorldPositionUpdatingSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.WorldPosition, GameMatcher.Transform));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.ReplaceWorldPosition(entity.Transform.position);
      }
    }
  }
}