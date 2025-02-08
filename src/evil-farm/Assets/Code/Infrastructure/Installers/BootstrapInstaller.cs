using Code.Gameplay.Common.Services.Identifier;
using Code.Gameplay.Common.Services.Physics;
using Code.Gameplay.Common.Services.Time;
using Code.Gameplay.Features.Input.Factory;
using Code.Gameplay.Features.Input.Service;
using Code.Infrastructure.Entities.Factory;
using Code.Infrastructure.Entities.Services;
using Code.Infrastructure.Entities.View.Factory;
using Code.Infrastructure.Services.AssetProviding;
using Code.Infrastructure.Services.Coroutines;
using Code.Infrastructure.Services.Scenes;
using Code.Infrastructure.Services.SystemFactory;
using Code.Infrastructure.States;
using Code.Infrastructure.UI.Loading;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
  {
    public LoadingCurtain Curtain;
    
    public void Initialize()
    {
      Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }

    public override void InstallBindings()
    {
      BindInstaller();
      BindCurtain();
      BindInfrastructureServices();
      BindGameStateMachine();
      BindContexts();
      BindCommonServices();
      BindGameplayServises();
    }

    private void BindCommonServices()
    {
      Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
      Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
      Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
    }

    private void BindGameplayServises()
    {
      Container.BindInterfacesTo<InputService>().AsSingle();
      Container.Bind<IInputFactory>().To<InputFactory>().AsSingle();
    }

    private void BindContexts()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }

    private void BindInstaller()
    {
      Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
    }

    private void BindCurtain()
    {
      ILoadingCurtain curtain = Container.InstantiatePrefabForComponent<LoadingCurtain>(Curtain);
      Container.Bind<ILoadingCurtain>().FromInstance(curtain);
    }

    private void BindInfrastructureServices()
    {
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
      
      Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
      Container.Bind<IEcsFactory>().To<EcsFactory>().AsSingle();
      Container.BindInterfacesTo<EcsProvider>().AsSingle();
      
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
      
    }

    private void BindGameStateMachine()
    {
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
    }
  }
}