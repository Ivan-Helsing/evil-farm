using Code.Gameplay.Features.Farmer.Factory;
using Code.Gameplay.Features.Farmer.Provider;
using Code.Gameplay.Features.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Systems
{
  public class InitializeFarmerSystem : IInitializeSystem
  {
    private readonly IFarmerBinder _binder;
    private readonly IFarmerFactory _factory;
    private readonly IInputService _input;

    public InitializeFarmerSystem(IFarmerBinder binder, IFarmerFactory factory, IInputService input)
    {
      _binder = binder;
      _factory = factory;
      _input = input;
    }

    public void Initialize()
    {
      GameEntity farmer = _factory.CreateFarmer();
      _binder.BindFarmerEntity(farmer);

      _input.Entity.AddOwnerId(farmer.Id);
    }
  }
}