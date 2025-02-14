using Code.Gameplay.Features.Plots;
using UnityEngine;

namespace Code.Infrastructure.WindowBase.Base
{
  public class PlantButton : MonoBehaviour
  {
    [SerializeField] private PlantTypeId TypeId;
    [SerializeField] private PlantWindow PlantWindow;

    public void Sow() => PlantWindow.Plant(TypeId);
  }
}