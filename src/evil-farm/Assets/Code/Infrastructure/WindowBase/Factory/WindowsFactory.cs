using System;
using Code.Infrastructure.Services.AssetProviding;
using Code.Infrastructure.WindowBase.Base;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.WindowBase.Factory
{
  public class WindowsFactory : IWindowsFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assets;

    public WindowsFactory(IInstantiator instantiator, IAssetProvider assets)
    {
      _instantiator = instantiator;
      _assets = assets;
    }

    public GameWindow Create(WindowTypeId typeId, Transform parent) => 
      _instantiator.InstantiatePrefabForComponent<GameWindow>(
        Window(typeId), 
        new Vector3(0, .5f, 0),
        Quaternion.identity, 
        parent);

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