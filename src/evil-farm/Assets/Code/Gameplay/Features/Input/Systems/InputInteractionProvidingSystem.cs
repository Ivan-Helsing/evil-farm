using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class InputInteractionProvidingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _farmer;

    public InputInteractionProvidingSystem(GameContext game)
    {
      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.OwnerId,
          GameMatcher.Interacted));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        
      }
    }
  }
}