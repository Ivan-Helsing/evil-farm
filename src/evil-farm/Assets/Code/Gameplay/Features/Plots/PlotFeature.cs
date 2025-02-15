using Code.Gameplay.Features.Plots.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features.Plots
{
  public sealed class PlotFeature : Feature
  {
    public PlotFeature(ISystemFactory systems)
    {
      Add(systems.Create<MenuPopupSystem>());
      
      Add(systems.Create<DataProvidingForSowingGrainsSystem>());
      Add(systems.Create<FarmerSwitchDestinationToSowingPlotSystem>());
      
      Add(systems.Create<CropGrowingSystem>());
      
      
      Add(systems.Create<PlotInteractionCleanupSystem>());
    }
  }
  
}