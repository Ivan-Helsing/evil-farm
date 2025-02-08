using Code.Infrastructure.Entities.View.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Infrastructure.Entities.View
{
  public class BindViewFeature : Feature
  {
    public BindViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindEntityViewFromPathSystem>());
      Add(systems.Create<BindEntityViewFromPrefabSystem>());
    }
  }
}