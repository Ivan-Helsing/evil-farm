using Code.Gameplay.Features.Plots;
using Code.Infrastructure.Entities.View;
using UnityEngine;

namespace Code.Infrastructure.WindowBase.Base
{
  public class PlantWindow : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour EntityView;

    public void Plant(PlantTypeId typeId, float growingDuration)
    {
      EntityView.Entity.AddGrowPlant(typeId);
      EntityView.Entity.AddGrowingDuration(growingDuration);
    }
  }
}