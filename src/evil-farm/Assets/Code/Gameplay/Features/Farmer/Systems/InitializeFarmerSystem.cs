using Code.Gameplay.Features.Farmer.Factory;
using Code.Gameplay.Features.Farmer.Provider;
using Code.Gameplay.Features.Input.Service;
using Code.Infrastructure.Services.Levels;
using Entitas;

namespace Code.Gameplay.Features.Farmer.Systems
{
  public class InitializeFarmerSystem : IInitializeSystem
  {
    private readonly IFarmerBinder _binder;
    private readonly IFarmerFactory _factory;
    private readonly IInputService _input;
    private readonly ILevelDataProvider _levelDataProvider;

    public InitializeFarmerSystem(IFarmerBinder binder, IFarmerFactory factory, IInputService input,
      ILevelDataProvider levelDataProvider)
    {
      _binder = binder;
      _factory = factory;
      _input = input;
      _levelDataProvider = levelDataProvider;
    }

    public void Initialize()
    {
      GameEntity farmer = _factory.CreateFarmer(_levelDataProvider.InitialPoint);
      _binder.BindFarmerEntity(farmer);

      _input.Entity.AddOwnerId(farmer.Id);
    }
  }
}