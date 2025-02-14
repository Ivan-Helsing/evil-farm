using Code.Common.Entities;
using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Identifier;
using Code.Infrastructure.Services.AssetProviding;
using Code.Infrastructure.WindowBase;
using UnityEngine;

namespace Code.Gameplay.Features.Plots.Factory
{
  public class PlotsFactory : IPlotsFactory
  {
    private readonly IIdentifierService _identifiers;

    public PlotsFactory(IIdentifierService identifiers) => 
      _identifiers = identifiers;

    public GameEntity CreatePlot(Vector3 at, Transform with)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.NextId())
          .AddWorldPosition(at)
          .AddViewPath(AssetPath.Plot)
          .AddParent(with)
          
          .AddWindowId(WindowTypeId.PlotMenu)
        
          .With(x=>x.isPlot = true)
          .With(x=>x.isArable = true)
        ;
    }
  }
}