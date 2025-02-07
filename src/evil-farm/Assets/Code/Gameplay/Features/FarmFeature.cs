using Code.Gameplay.Features.Input;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features
{
  public class FarmFeature : Feature
  {
    public FarmFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
    }
  }
}