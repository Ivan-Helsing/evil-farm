using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class CharacterMovingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _characters;
    private readonly List<GameEntity> _buffer = new (8);

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
      foreach (GameEntity character in _characters.GetEntities(_buffer))
      {
        character.CharacterMover.Move(character.Direction, character.Speed);
      }
    }
  }
}