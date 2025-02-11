namespace Code.Infrastructure.WindowBase.Service
{
  public interface IWindowsService
  {
    void ShowPlotMenu();
    void Close(WindowTypeId windowId);
  }
}