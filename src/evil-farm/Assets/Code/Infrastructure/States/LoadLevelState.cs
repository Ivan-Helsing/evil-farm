using Code.Infrastructure.Entities.Services;
using Code.Infrastructure.UI.Loading;
using UnityEngine;

namespace Code.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILoadingCurtain _curtain;
    private readonly IEcsBinder _ecsRunner;

    public LoadLevelState(IGameStateMachine stateMachine, ILoadingCurtain curtain, IEcsBinder ecsRunner)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
      _ecsRunner = ecsRunner;
    }
    
    public void Enter()
    {
      _curtain.Hide();

      InitGameWorld();
      
      _stateMachine.Enter<GameLoopState>();
      Debug.Log("LoadLevel Entered");
    }

    private void InitGameWorld()
    {
      _ecsRunner.CreateInstance();
    }

    public void Exit()
    {
    }
  }
}