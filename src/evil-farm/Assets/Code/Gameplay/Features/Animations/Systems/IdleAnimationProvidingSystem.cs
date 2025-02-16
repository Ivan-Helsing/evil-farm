using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
  public class IdleAnimationProvidingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _animateds;
    private readonly List<GameEntity> _buffer = new (8);

    public IdleAnimationProvidingSystem(GameContext game)
    {
      _animateds = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AnimationsId,
          GameMatcher.ChangingAnimationState));
    }

    public void Execute()
    {
      foreach (GameEntity animated in _animateds.GetEntities(_buffer))
      {
        animated.isReadyToSwitchAnimation = true;
        animated.ReplaceAnimationsId(AnimationTypeId.Idle);

        animated.isChangingAnimationState = false;
      }
    }
  }
}