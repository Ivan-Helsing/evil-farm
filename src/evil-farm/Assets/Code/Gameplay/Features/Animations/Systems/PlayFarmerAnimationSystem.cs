using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Animations.Systems
{
  public class PlayFarmerAnimationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _farmers;
    private readonly List<GameEntity> _buffer = new (4);

    public PlayFarmerAnimationSystem(GameContext game)
    {
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Farmer,
          GameMatcher.AnimationsId,
          GameMatcher.FarmerAnimator,
          GameMatcher.ReadyToSwitchAnimation));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers.GetEntities(_buffer))
      {
        farmer.isReadyToSwitchAnimation = false;
        farmer.FarmerAnimator.Play(animation: farmer.AnimationsId);
      }
    }
  }
}