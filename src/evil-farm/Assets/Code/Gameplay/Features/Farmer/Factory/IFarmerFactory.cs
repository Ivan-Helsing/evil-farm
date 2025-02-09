using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Factory
{
  public interface IFarmerFactory
  {
    GameEntity CreateFarmer(Vector3 initialPoint);
  }
}