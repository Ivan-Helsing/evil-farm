using Code.Common.Entities;
using Code.Gameplay.Common.Services.Identifier;
using Code.Infrastructure.Services.AssetProviding;
using UnityEngine;

namespace Code.Gameplay.Features.Cameras.Factory
{
  public class CameraFactory : ICameraFactory
  {
    private readonly IIdentifierService _identifiers;

    public CameraFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateCamera()
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.NextId())
          .AddViewPath(AssetPath.Camera)
          .AddWorldPosition(Vector3.zero)
          
          .AddDistance(6f)
          .AddOffset(-4f)
          .AddAngleX(55)
          
        ;
    }
  }
}