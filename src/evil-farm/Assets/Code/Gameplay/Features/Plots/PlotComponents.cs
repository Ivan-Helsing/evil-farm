using Code.Gameplay.Features.Plots.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Plots
{
  [Game] public class Plot : IComponent {}
  [Game] public class Arable : IComponent {}
  [Game] public class MenuProvided : IComponent {}
  
  [Game] public class InteractionProviderComponent : IComponent { public InteractionProvider Value; }
  [Game] public class GrowPlant : IComponent { public PlantTypeId Value; }
}