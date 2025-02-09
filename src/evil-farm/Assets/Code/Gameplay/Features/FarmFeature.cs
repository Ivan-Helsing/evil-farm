using Code.Common.Destruct;
using Code.Gameplay.Features.Cameras;
using Code.Gameplay.Features.Farmer.Systems;
using Code.Gameplay.Features.Input;
using Code.Gameplay.Features.Movement;
using Code.Infrastructure.Entities.View;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features
{
  public class FarmFeature : Feature
  {
    public FarmFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindViewFeature>());
      
      Add(systems.Create<InputFeature>());
      Add(systems.Create<FarmerFeature>());
      Add(systems.Create<MovementFeature>());

      Add(systems.Create<CameraFeature>());

      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}