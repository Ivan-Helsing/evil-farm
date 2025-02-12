using Code.Infrastructure.WindowBase.Base;
using UnityEngine;

namespace Code.Infrastructure.WindowBase.Factory
{
  public interface IWindowsFactory
  {
    GameWindow Create(WindowTypeId typeId, Transform parent);
  }
}