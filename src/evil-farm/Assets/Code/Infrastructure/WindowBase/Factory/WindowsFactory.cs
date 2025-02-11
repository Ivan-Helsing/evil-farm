using System;
using Code.Infrastructure.Services.AssetProviding;
using Code.Infrastructure.WindowBase.Base;
using Zenject;

namespace Code.Infrastructure.WindowBase.Factory
{
  public class WindowsFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assets;

    public WindowsFactory(IInstantiator instantiator, IAssetProvider assets)
    {
      _instantiator = instantiator;
      _assets = assets;
    }

    public GameWindow Create(WindowTypeId typeId) => 
      _instantiator.InstantiatePrefabForComponent<GameWindow>(Window(typeId));

    private GameWindow Window(WindowTypeId typeId)
    {
      switch (typeId)
      {
        case WindowTypeId.PlotMenu:
          return _assets.LoadAsset<GameWindow>(AssetPath.PlotMenu);
      }

      throw new Exception($"Window type {typeId} is not supported");
    }
  }
}