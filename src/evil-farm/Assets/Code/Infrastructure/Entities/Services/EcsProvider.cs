using Code.Infrastructure.Entities.Factory;

namespace Code.Infrastructure.Entities.Services
{
  public class EcsProvider : IEcsProvider, IEcsBinder
  {
    private readonly IEcsFactory _factory;
    
    private EcsRunner _runner;
    public EcsRunner Runner => _runner;

    public EcsProvider(IEcsFactory factory) => 
      _factory = factory;

    public void CreateInstance() => 
      _runner = _factory.CreateEcsRunner<EcsRunner>();

    public void DestroyInstance() => 
      _runner = null;
  }
}