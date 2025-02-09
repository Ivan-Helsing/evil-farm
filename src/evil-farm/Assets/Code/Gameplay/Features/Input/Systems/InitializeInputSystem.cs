using Code.Gameplay.Features.Input.Factory;
using Code.Gameplay.Features.Input.Service;
using Code.Infrastructure.Services.AssetProviding;
using Entitas;

namespace Code.Gameplay.Features.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    private readonly IInputFactory _factory;
    private readonly IInputBinder _inputBinder;

    public InitializeInputSystem(IInputFactory factory, IInputBinder inputBinder)
    {
      _factory = factory;
      _inputBinder = inputBinder;
    }

    public void Initialize()
    {
      GameEntity input = _factory.CreateInputProvider();
      
      _inputBinder.SetupInputEntity(input);
    }
  }
}