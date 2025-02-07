namespace Code.Infrastructure.Entities.View
{
  public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
  {
    public abstract void RegisterComponents();
    public abstract void UnregisterComponents();
  }
}