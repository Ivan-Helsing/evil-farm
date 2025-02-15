using Code.Gameplay.Features.Farmer.Behaviours;
using Code.Infrastructure.Entities.View.Registrars;

namespace Code.Gameplay.Features.Farmer.Registrars
{
  public class FarmerAnimatorRegistrar : EntityComponentRegistrar
  {
    public FarmerAnimator Animator;

    public override void RegisterComponents() => 
      Entity.AddFarmerAnimator(Animator);

    public override void UnregisterComponents()
    {
      if(Entity.hasFarmerAnimator)
        Entity.RemoveFarmerAnimator();
    }
  }
}