namespace Code.Infrastructure.Entities.View
{
  public interface IEntityComponentRegistrar
  {
    void RegisterComponents();
    void UnregisterComponents();
  }
}