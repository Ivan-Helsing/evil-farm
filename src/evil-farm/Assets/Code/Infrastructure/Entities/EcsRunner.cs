using Code.Gameplay.Features;
using Code.Infrastructure.Services.SystemFactory;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Entities
{
  public class EcsRunner : MonoBehaviour
  {
    private FarmFeature _farmFeature;
    private ISystemFactory _systems;

    [Inject]
    public void Construct(ISystemFactory systems) => 
      _systems = systems;

    private void Start()
    {
      _farmFeature = _systems.Create<FarmFeature>();
      _farmFeature.Initialize();
    }

    private void Update()
    {
      _farmFeature.Execute();
      _farmFeature.Cleanup();
    }

    private void OnDestroy()
    {
      _farmFeature.TearDown();
    }
  }
}