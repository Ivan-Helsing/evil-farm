using System.Collections.Generic;
using Code.Gameplay.Features.Cameras.Provider;
using Code.Gameplay.Features.Farmer.Provider;
using Code.Gameplay.Features.Input.Service;
using Code.Gameplay.Features.Plots.Factory;
using Code.Infrastructure.Entities.Services;
using Code.Infrastructure.Services.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class LevelInitializer : MonoBehaviour, IInitializable
  {
    [SerializeField] private Transform _initialPoint;
    [SerializeField] private List<Transform> _plotsPosition;
    
    private ILevelDataBinder _levelDataBinder;
    private IEcsBinder _ecsBinder;
    private ICameraBinder _cameraBinder;
    private IFarmerBinder _farmer;
    private IInputBinder _input;
    private IPlotsFactory _plotsFactory;

    [Inject]
    public void Construct(ILevelDataBinder levelDataBinder, IFarmerBinder farmer, 
      ICameraBinder cameraBinder, IInputBinder inputBinder, IEcsBinder ecsBinder,
      IPlotsFactory plotsFactory)
    {
      _levelDataBinder = levelDataBinder;
      _farmer = farmer;
      _cameraBinder = cameraBinder;
      _input = inputBinder;
      _ecsBinder = ecsBinder;
      _plotsFactory = plotsFactory;
    }
    
    public void Initialize()
    {
      _levelDataBinder.BindInitialPoint(_initialPoint.position);
      
      GameEntity farmer = _farmer.Setup();
      
      _cameraBinder.Setup(farmer.Id);
      _input.Setup(farmer.Id);

      PlotsInitialization();
      
      _ecsBinder.CreateInstance();
    }

    private void PlotsInitialization()
    {
      foreach (Transform parent in _plotsPosition) 
        _plotsFactory.CreatePlot(at: parent.position, with: parent);
    }
  }
}