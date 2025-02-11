using Code.Infrastructure.WindowBase.Service;
using UnityEngine;

namespace Code.Gameplay.Features.Plots.Behaviours
{
  public class PlotController : MonoBehaviour
  {
    private IWindowsService _windows;

    public void Interact()
    {
      _windows.ShowPlotMenu();
    }
  }
}