using Code.Infrastructure.WindowBase;
using Code.Infrastructure.WindowBase.Service;
using UnityEngine;

namespace Code.Gameplay.Features.Plots.Behaviours
{
  public class InteractionProvider : MonoBehaviour
  {
    private IWindowsService _windows;

    public void Interact(WindowTypeId window, Transform parent) => 
      _windows.Show(window, parent);
  }
}