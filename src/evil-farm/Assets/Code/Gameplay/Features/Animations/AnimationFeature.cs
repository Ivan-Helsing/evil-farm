using Code.Gameplay.Features.Animations.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features.Animations
{
  public sealed class AnimationFeature : Feature
  {
    public AnimationFeature(ISystemFactory systems)
    {
      Add(systems.Create<HarvestingAnimationProvidingSystem>());
      Add(systems.Create<SowingAnimationProvidingSystem>());
      Add(systems.Create<RunningAnimationProvidingSystem>());
      Add(systems.Create<IdleAnimationProvidingSystem>());
      
      Add(systems.Create<PlayFarmerAnimationSystem>());
    }
  }
}