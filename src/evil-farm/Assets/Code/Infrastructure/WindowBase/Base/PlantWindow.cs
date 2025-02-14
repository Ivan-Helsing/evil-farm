using Code.Gameplay.Features.Plots;
using Code.Infrastructure.Entities.View;
using UnityEngine;

namespace Code.Infrastructure.WindowBase.Base
{
  public class PlantWindow : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour EntityView;

    public void Plant(PlantTypeId typeId)
    {
      EntityView.Entity.AddGrowPlant(typeId);
      // _parentEntity.Arable = false;
      // _parentEntity.AddPlantTypeId(typeId);
      // _parentEntity.
    }
  }
}