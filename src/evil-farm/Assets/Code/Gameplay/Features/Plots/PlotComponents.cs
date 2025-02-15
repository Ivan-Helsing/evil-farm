using Code.Gameplay.Features.Plots.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Plots
{
  [Game] public class Plot : IComponent {}
  [Game] public class Arable : IComponent {}
  [Game] public class Sowed : IComponent {}
  [Game] public class ReadyToHarvest : IComponent {}
  [Game] public class ReadyToBeSowed : IComponent {}

  [Game] public class InteractionProviderComponent : IComponent { public InteractionProvider Value; }
  [Game] public class GrowPlant : IComponent { public PlantTypeId Value; }
  [Game] public class GrowingDuration : IComponent { public float Value; }
  [Game] public class GrowingTimer : IComponent { public float Value; }
}