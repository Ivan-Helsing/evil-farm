using Code.Infrastructure.WindowBase;
using Code.Infrastructure.WindowBase.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Plots.Behaviours
{
  public class InteractionProvider : MonoBehaviour
  {
    private IWindowsService _windows;

    [Inject]
    public void Construct(IWindowsService windows) => 
      _windows = windows;

    public GameEntity Interact(WindowTypeId window) => 
      _windows.Show(window);
  }
}