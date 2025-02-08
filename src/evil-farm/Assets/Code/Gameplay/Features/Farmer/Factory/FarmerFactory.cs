using Code.Common.Entities;
using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Identifier;
using Code.Infrastructure.Services.AssetProviding;
using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Factory
{
  public class FarmerFactory : IFarmerFactory
  {
    private readonly IIdentifierService _identifiers;

    public FarmerFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateFarmer()
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.NextId())
          .AddViewPath(AssetPath.Farmer)
          .AddWorldPosition(Vector3.zero)
          
          .With(x => x.isFarmer = true)
        ;
    }
  }
}