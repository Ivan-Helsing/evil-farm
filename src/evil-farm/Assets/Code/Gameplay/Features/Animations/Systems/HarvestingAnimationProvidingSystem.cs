using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
  public class HarvestingAnimationProvidingSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _animateds;
    private readonly List<GameEntity> _buffer = new (8);

    public HarvestingAnimationProvidingSystem(GameContext game)
    {
      _animateds = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Harvesting,
          GameMatcher.AnimationsId,
          GameMatcher.ChangingAnimationState));
    }

    public void Execute()
    {
      foreach (GameEntity animated in _animateds.GetEntities(_buffer))
      {
        animated.isReadyToSwitchAnimation = true;
        animated.ReplaceAnimationsId(AnimationTypeId.Harvest);

        animated.isHarvesting = false;
        animated.isChangingAnimationState = false;
      }
    }
  }
}