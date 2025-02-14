using System;
using Code.Common.Entities;
using Code.Common.Extensions;
using Code.Gameplay.Common.Services.Identifier;
using Code.Infrastructure.Services.AssetProviding;

namespace Code.Infrastructure.WindowBase.Factory
{
  public class WindowsFactory : IWindowsFactory
  {
    private readonly IIdentifierService _identifiers;

    public WindowsFactory(IIdentifierService identifiers) => 
      _identifiers = identifiers;

    public GameEntity Create(WindowTypeId typeId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.NextId())
          .AddWindowId(typeId)
          .AddViewPath(WindowPath(typeId))
          
          .With(x=>x.isPlantWindow = true)
        ;
    }

    private string WindowPath(WindowTypeId windowTypeId)
    {
      switch (windowTypeId)
      {
        case WindowTypeId.PlotMenu:
          return AssetPath.PlotMenu;
      }
      throw new Exception("Unknown window type");
    }
  }
}