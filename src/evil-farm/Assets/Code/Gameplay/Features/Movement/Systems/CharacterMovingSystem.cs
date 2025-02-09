using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class CharacterMovingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _characters;

    public CharacterMovingSystem(GameContext game)
    {
      _characters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CharacterMover,
          GameMatcher.Direction,
          GameMatcher.Speed,
          GameMatcher.Moving,
          GameMatcher.MovementAvailable));
    }

    public void Execute()
    {
      foreach (GameEntity character in _characters)
      {
        character.CharacterMover.Move(character.Direction, character.Speed);
      }
    }
  }
}