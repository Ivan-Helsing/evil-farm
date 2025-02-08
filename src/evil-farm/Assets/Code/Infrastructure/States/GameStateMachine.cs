using System;
using System.Collections.Generic;

namespace Code.Infrastructure.States
{
  public class GameStateMachine : IGameStateMachine
  {
    private readonly Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine(IStateFactory states)
    {
      _states = new Dictionary<Type, IState>
      {
        [typeof(BootstrapState)] = states.Create<BootstrapState>(this),
        [typeof(LoadLevelState)] = states.Create<LoadLevelState>(this),
        [typeof(GameLoopState)] = states.Create<GameLoopState>(),
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      _activeState?.Exit();
      
      IState state = ChangeState<TState>();

      state.Enter();
    }

    private IState ChangeState<TState>() where TState : class, IState
    {
      TState state = _states[typeof(TState)] as TState;
      _activeState = state;
      return state;
    }
  }
}