using Code.Gameplay.Features.Input.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features.Input
{
  public sealed class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      
      // Add(systems.Create<InitializeInputSystem>());
    }
  }
}