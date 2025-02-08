namespace Code.Infrastructure.Entities.Services
{
  public interface IEcsProvider
  {
    EcsRunner Runner { get; }
  }
}