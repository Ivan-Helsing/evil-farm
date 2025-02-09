using Code.Gameplay.Common.Services.Physics;
using Code.Gameplay.Features.Cameras.Provider;
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
    private ICameraProvider _camera;

    [Inject]
    public void Construct(IInputService input, IPhysicsService physics, ICameraProvider camera)
    {
      _input = input;
      _physics = physics;
      _camera = camera;
    }

    public void OnMove(InputValue value) =>
      _input.Entity.isWalkingProvided = true;
    
    public void OnGrantDestination(InputValue value) => 
      _input.Entity.isDestinationGranted = true;

    public void OnInteract(InputValue value) =>
      _input.Entity.isInteracted = true;

    public void OnLook(InputValue value)
    {
      _input.Entity.ReplaceWalkablePoint(Position(value));
      _input.Entity.ReplaceCursorPosition(value.Get<Vector2>());
    }

    private Vector3 Position(InputValue value) => 
      _physics.RaycastHit(from: value.Get<Vector2>(), with: _camera.Entity.MainCamera);
  }
}