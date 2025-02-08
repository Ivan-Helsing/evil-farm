using Code.Common.Destruct.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Common.Destruct
{
  public sealed class ProcessDestructedFeature : Feature
  {
    public ProcessDestructedFeature(ISystemFactory systems)
    {
      Add(systems.Create<CleanupGameDestructedSystem>());
      Add(systems.Create<CleanupGameDestructedViewSystem>());
    }
  }
}