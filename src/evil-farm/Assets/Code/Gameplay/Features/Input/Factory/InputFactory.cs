﻿using Code.Common.Entities;
using Code.Gameplay.Common.Services.Identifier;
using Code.Infrastructure.Services.AssetProviding;
using UnityEngine;

namespace Code.Gameplay.Features.Input.Factory
{
  public class InputFactory : IInputFactory
  {
    private readonly IIdentifierService _identifiers;

    public InputFactory(IIdentifierService identifiers) => 
      _identifiers = identifiers;

    public GameEntity CreateInputProvider()
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.NextId())
          .AddViewPath(AssetPath.InputProvider)
          .AddWorldPosition(Vector3.zero)
        ;
    }
  }
}