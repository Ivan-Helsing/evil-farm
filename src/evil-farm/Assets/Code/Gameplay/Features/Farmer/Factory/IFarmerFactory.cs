using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Factory
{
  public interface IFarmerFactory
  {
    GameEntity Create(Vector3 initialPoint);
  }
}