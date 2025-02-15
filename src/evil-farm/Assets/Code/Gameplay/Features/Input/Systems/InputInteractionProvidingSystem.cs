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
          CleanupLastPlot(farmer);

          target.isInteracted = true;
          target.ReplaceTargetId(input.OwnerId);
          
          farmer.ReplaceTargetId(input.TargetId);
          farmer.ReplaceDestinationRadius(target.DestinationRadius);
        }
      }
    }

    private void CleanupLastPlot(GameEntity farmer)
    {
      GameEntity plot = _game.GetEntityWithId(farmer.TargetId);
      plot.isReadyToCleanup = true;
    }
  }
}