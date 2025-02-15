using Code.Gameplay.Features.Farmer.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Farmer
{
  [Game] public class Farmer : IComponent {}
  
  [Game] public class PerformingSow : IComponent {}
  [Game] public class Harvesting : IComponent {}
  
  [Game] public class FarmerAnimatorComponent : IComponent { public FarmerAnimator Value; }
}