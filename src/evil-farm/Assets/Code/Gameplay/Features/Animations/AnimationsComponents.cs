using Code.Gameplay.Features.Farmer.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Animations
{
  [Game] public class ChangingAnimationState : IComponent {}
  [Game] public class ReadyToSwitchAnimation : IComponent {}

  [Game] public class FarmerAnimatorComponent : IComponent { public FarmerAnimator Value; }
  [Game] public class AnimationsId : IComponent { public AnimationTypeId Value; }
}