using UnityEngine;

namespace Code.Infrastructure.States
{
  public class GameLoopState : IState
  {
    public void Enter()
    {
      Debug.Log("Game loop entered");
    }

    public void Exit()
    {
    }
  }
}