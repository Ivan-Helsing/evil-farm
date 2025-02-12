using Code.Infrastructure.WindowBase.Factory;
using UnityEngine;

namespace Code.Infrastructure.WindowBase.Service
{
  public class WindowsService : IWindowsService
  {
    private readonly IWindowsFactory _factory;

    public WindowsService(IWindowsFactory factory)
    {
      _factory = factory;
    }

    public void Show(WindowTypeId typeId, Transform parent) => 
      _factory.Create(typeId, parent);
  }
}