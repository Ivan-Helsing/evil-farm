using Code.Gameplay.Common.Services.Physics;
using Code.Gameplay.Features.Input.Service;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.Gameplay.Features.Input.Behaviours
{
  public class InputProvider : MonoBehaviour
  {
    private IInputService _input;
    private IPhysicsService _physics;

    private Vector2 _cursorLastPosition;
    private Vector3 _walkablePoint;
    private bool _isClicked;

    [Inject]
    public void Construct(IInputService input, IPhysicsService physics)
    {
      _input = input;
      _physics = physics;
    }

    public void OnMove(InputValue value) => 
      _input.Entity.isWalkingProvided = true;
    
    public void OnInteract(InputValue value) => 
      _input.Entity.isInteracted = true;

    public void OnLook(InputValue value)
    {
      _input.Entity.ReplaceWalkablePoint(_physics.RaycastHit(value.Get<Vector2>()));
      _input.Entity.ReplaceCursorPosition(value.Get<Vector2>());
    }
  }
}