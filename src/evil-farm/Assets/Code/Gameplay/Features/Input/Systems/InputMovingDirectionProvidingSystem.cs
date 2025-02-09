using Code.Gameplay.Common.Services.Screens;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class InputMovingDirectionProvidingSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _inputs;
    private readonly IScreenService _screen;

    public InputMovingDirectionProvidingSystem(GameContext game, IScreenService screen)
    {
      _game = game;
      _screen = screen;
      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Input,
          GameMatcher.OwnerId,
          GameMatcher.WalkingProvided,
          GameMatcher.CursorPosition)
        .NoneOf(GameMatcher.DestinationGranted));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        GameEntity farmer = _game.GetEntityWithId(input.OwnerId);
        
        farmer.ReplaceDirection(_screen.BindZeroToCenter(input.CursorPosition));
        farmer.isMoving = true;

        if (farmer.hasDestinationPoint)
          farmer.RemoveDestinationPoint();
      }
    }
  }
}