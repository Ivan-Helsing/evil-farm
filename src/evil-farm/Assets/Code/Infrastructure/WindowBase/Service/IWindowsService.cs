namespace Code.Infrastructure.WindowBase.Service
{
  public interface IWindowsService
  {
    GameEntity Show(WindowTypeId typeId);
  }
}