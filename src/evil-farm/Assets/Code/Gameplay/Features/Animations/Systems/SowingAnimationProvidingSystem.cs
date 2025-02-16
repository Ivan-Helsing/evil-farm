using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
  public class SowingAnimationProvidingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _animateds;
    private readonly List<GameEntity> _buffer = new (8);

    public SowingAnimationProvidingSystem(GameContext game)
    {
      _animateds = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Sowing,
          GameMatcher.AnimationsId,
          GameMatcher.ChangingAnimationState));
    }

    public void Execute()
    {
      foreach (GameEntity animated in _animateds.GetEntities(_buffer))
      {
        animated.isReadyToSwitchAnimation = true;
        animated.ReplaceAnimationsId(AnimationTypeId.Sow);

        animated.isSowing = false;
        animated.isChangingAnimationState = false;
      }
    }
  }
}