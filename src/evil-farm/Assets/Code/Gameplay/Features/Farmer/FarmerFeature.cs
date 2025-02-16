using Code.Gameplay.Features.Farmer.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features.Farmer
{
  public sealed class FarmerFeature : Feature
  {
    public FarmerFeature(ISystemFactory systems)
    {
      Add(systems.Create<DirectionProvidedFromDestinationPointSystem>());
    }
  }
}