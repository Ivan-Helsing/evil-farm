namespace Code.Infrastructure.Entities.View.Registrars
{
  public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
  {
    public abstract void RegisterComponents();
    public abstract void UnregisterComponents();
  }
}