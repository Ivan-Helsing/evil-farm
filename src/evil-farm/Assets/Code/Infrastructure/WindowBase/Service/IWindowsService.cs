using UnityEngine;

namespace Code.Infrastructure.WindowBase.Service
{
  public interface IWindowsService
  {
    void Show(WindowTypeId typeId, Transform parent);
  }
}