﻿using Code.Infrastructure.Services.Coroutines;
using Code.Infrastructure.Services.Scenes;
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
      Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
    }

    private void BindGameStateMachine()
    {
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
    }
  }
}