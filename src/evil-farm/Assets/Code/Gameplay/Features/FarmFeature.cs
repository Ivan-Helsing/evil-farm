using Code.Common.Destruct;
using Code.Gameplay.Features.Input;
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
      
      
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}