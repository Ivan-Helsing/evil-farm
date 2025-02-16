using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Farmer.Systems
{
  public class PlayAnimationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _farmers;
    private readonly List<GameEntity> _buffer = new (4);

    public PlayAnimationSystem(GameContext game)
    {
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Farmer,
          GameMatcher.AnimationsId,
          GameMatcher.FarmerAnimator,
          GameMatcher.ChangingAnimationState));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers.GetEntities(_buffer))
      {
        farmer.FarmerAnimator.Play(animation: farmer.AnimationsId);
        farmer.isChangingAnimationState = false;
      }
    }
  }
}