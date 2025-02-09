using Code.Infrastructure.UI.Loading;

namespace Code.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILoadingCurtain _curtain;

    public LoadLevelState(IGameStateMachine stateMachine, ILoadingCurtain curtain)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
    }
    
    public void Enter()
    {
      _curtain.Hide();

      _stateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {
    }
  }
}