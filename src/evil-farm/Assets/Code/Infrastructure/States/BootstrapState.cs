using Code.Infrastructure.Services.Scenes;
using Code.Infrastructure.UI.Loading;

namespace Code.Infrastructure.States
{
  public class BootstrapState: IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ILoadingCurtain _curtain;
    private readonly ISceneLoader _scenes;

    public BootstrapState(IGameStateMachine stateMachine, ILoadingCurtain curtain, ISceneLoader scenes)
    {
      _stateMachine = stateMachine;
      _curtain = curtain;
      _scenes = scenes;
    }
    
    public void Enter()
    {
      _curtain.Show();
      
      _scenes.LoadScene("Main", MoveToNextState);
    }

    public void Exit()
    {
      
    }

    private void MoveToNextState() => 
      _stateMachine.Enter<LoadLevelState>();
  }
}