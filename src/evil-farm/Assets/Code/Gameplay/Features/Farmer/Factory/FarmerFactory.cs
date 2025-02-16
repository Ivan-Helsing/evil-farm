using Code.Common.Entities;
using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Identifier;
using Code.Gameplay.Features.Animations;
using Code.Infrastructure.Services.AssetProviding;
using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Factory
{
  public class FarmerFactory : IFarmerFactory
  {
    private readonly IIdentifierService _identifiers;

    public FarmerFactory(IIdentifierService identifiers) => 
      _identifiers = identifiers;

    public GameEntity Create(Vector3 initialPoint)
    {
      int selfId = _identifiers.NextId();
      
      return CreateEntity.Empty()
          .AddId(selfId)
          .AddViewPath(AssetPath.Farmer)
          .AddWorldPosition(initialPoint)
          
          .AddSpeed(5)
          .AddAnimationsId(AnimationTypeId.Idle)
          
          .AddTargetId(selfId)
          
          .With(x => x.isFarmer = true)
          .With(x => x.isMovementAvailable = true)
        ;
    }
  }
}