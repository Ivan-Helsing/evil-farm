using Code.Common.Entities;
using Code.Infrastructure.Services.AssetProviding;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Input.Factory
{
  public class InputFactory : IInputFactory
  {
    private readonly IInstantiator _instantiator;

    public InputFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    public GameEntity CreateInputProvider()
    {
      return CreateEntity.Empty()
          .AddViewPath(AssetPath.InputProvider)
          .AddWorldPosition(Vector3.zero)
        ;
    }
  }
}