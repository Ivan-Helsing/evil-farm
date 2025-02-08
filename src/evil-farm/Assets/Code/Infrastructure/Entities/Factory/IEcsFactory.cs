namespace Code.Infrastructure.Entities.Factory
{
  public interface IEcsFactory
  {
    T CreateEcsRunner<T>();
  }
}