using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Gameplay.Features.Input.Behaviours
{
  public class InputProvider : MonoBehaviour
  {
    private Vector2 _cursorLastPosition;

    public void OnMove(InputValue value)
    {
      
    }

    public void OnLook(InputValue value)
    {
      _cursorLastPosition = value.Get<Vector2>();
    }
  }
}