using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
  public class RunningAnimationProvidingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _animateds;
    private readonly List<GameEntity> _buffer = new(8);

    public RunningAnimationProvidingSystem(GameContext game)
    {
      _animateds = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Speed,
          GameMatcher.Direction,
          GameMatcher.Moving,
          GameMatcher.MovementAvailable,
          GameMatcher.AnimationsId,
          GameMatcher.ChangingAnimationState));
    }

    public void Execute()
    {
      foreach (GameEntity animated in _animateds.GetEntities(_buffer))
      {
        animated.isReadyToSwitchAnimation = true;
        animated.ReplaceAnimationsId(AnimationTypeId.Run);

        animated.isChangingAnimationState = false;
      }
    }
  }
}