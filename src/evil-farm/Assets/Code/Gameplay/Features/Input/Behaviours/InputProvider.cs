using Code.Gameplay.Features.Input.Service;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.Gameplay.Features.Input.Behaviours
{
  public class InputProvider : MonoBehaviour
  {
    private Vector2 _cursorLastPosition;
    private IInputService _input;

    [Inject]
    public void Construct(IInputService input) => 
      _input = input;

    public void OnMove(InputValue value)
    {
      Debug.Log(_cursorLastPosition);
      // _input.Entity.AddMovingDirection(_cursorLastPosition);
    }

    public void OnLook(InputValue value)
    {
      _cursorLastPosition = value.Get<Vector2>();
    }
  }
}