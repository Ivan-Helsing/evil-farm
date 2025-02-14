using Code.Gameplay.Features.Plots.Behaviours;
using Code.Infrastructure.Entities.View.Registrars;

namespace Code.Gameplay.Features.Plots.Registrars
{
  public class InteractionProviderRegistrar : EntityComponentRegistrar
  {
    public InteractionProvider Provider;

    public override void RegisterComponents()
    {
      Entity.AddInteractionProvider(Provider);
    }

    public override void UnregisterComponents()
    {
      if(Entity.hasInteractionProvider)
        Entity.RemoveInteractionProvider();
    }
  }
}