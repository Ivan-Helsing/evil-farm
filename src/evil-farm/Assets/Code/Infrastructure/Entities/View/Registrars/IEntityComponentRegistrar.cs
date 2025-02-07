namespace Code.Infrastructure.Entities.View.Registrars
{
  public interface IEntityComponentRegistrar
  {
    void RegisterComponents();
    void UnregisterComponents();
  }
}