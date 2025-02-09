using Code.Infrastructure.Entities.Services;
using Code.Infrastructure.Services.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class LevelInitializer : MonoBehaviour, IInitializable
  {
    [SerializeField] private Transform _initialPoint;
    
    private ILevelDataBinder _levelDataBinder;
    private IEcsBinder _ecsBinder;

    [Inject]
    public void Construct(ILevelDataBinder levelDataBinder, IEcsBinder ecsBinder)
    {
      _levelDataBinder = levelDataBinder;
      _ecsBinder = ecsBinder;
    }
    
    public void Initialize()
    {
      _levelDataBinder.BindInitialPoint(_initialPoint.position);
      _ecsBinder.CreateInstance();
    }
  }
}