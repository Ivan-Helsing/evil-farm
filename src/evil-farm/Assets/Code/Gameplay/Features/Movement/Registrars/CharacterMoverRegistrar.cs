using Code.Gameplay.Features.Movement.Behaviours;
using Code.Infrastructure.Entities.View.Registrars;

namespace Code.Gameplay.Features.Movement.Registrars
{
  public class CharacterMoverRegistrar : EntityComponentRegistrar
  {
    public CharacterMover Mover;
    
    public override void RegisterComponents() => 
      Entity.AddCharacterMover(Mover);

    public override void UnregisterComponents()
    {
      if (Entity.hasCharacterMover)
        Entity.RemoveCharacterMover();
    }
  }
}