using Entitas;

namespace Code.Gameplay.Features.Farmer.Systems
{
  public class AnimationProviderSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _farmers;

    public AnimationProviderSystem(GameContext game)
    {
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Farmer,
          GameMatcher.FarmerAnimator));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers)
      {
        
      }
    }
  }
}