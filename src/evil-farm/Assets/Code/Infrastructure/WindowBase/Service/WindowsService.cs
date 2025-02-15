using Code.Infrastructure.WindowBase.Factory;

namespace Code.Infrastructure.WindowBase.Service
{
  public class WindowsService : IWindowsService
  {
    private readonly IWindowsFactory _factory;

    public WindowsService(IWindowsFactory factory)
    {
      _factory = factory;
    }

    public GameEntity Show(WindowTypeId typeId) => 
      _factory.Create(typeId);
  }
}