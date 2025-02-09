using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class InputDestinationProvidingSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _inputs;

    public InputDestinationProvidingSystem(GameContext game)
    {
      _game = game;
      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.WalkablePoint,
          GameMatcher.DestinationGranted));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        GameEntity farmer = _game.GetEntityWithId(input.OwnerId);
        
        farmer.AddDestinationPoint(input.WalkablePoint);
      }
    }
  }
}