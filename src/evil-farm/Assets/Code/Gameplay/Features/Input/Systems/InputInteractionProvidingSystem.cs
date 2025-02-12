using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class InputInteractionProvidingSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _farmer;

    public InputInteractionProvidingSystem(GameContext game)
    {
      _game = game;
      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.OwnerId,
          GameMatcher.Interacted,
          GameMatcher.TargetId));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        GameEntity farmer = _game.GetEntityWithId(input.OwnerId);
        GameEntity target = _game.GetEntityWithId(input.TargetId);

        if (farmer.TargetId != target.Id)
        {
          target.isInteracted = true;
          farmer.ReplaceTargetId(input.TargetId);
        }
      }
    }
  }
}