using Code.Infrastructure.WindowBase.Base;

namespace Code.Infrastructure.WindowBase.Factory
{
  public interface IWindowsFactory
  {
    GameEntity Create(WindowTypeId typeId);
  }
}