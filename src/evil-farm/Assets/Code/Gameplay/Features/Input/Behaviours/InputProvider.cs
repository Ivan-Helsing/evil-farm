using Code.Gameplay.Common.Services.Collisions;
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

    public void OnLook(InputValue value) => 
      _cursorLastPosition = value.Get<Vector2>();

    public void OnMove(InputValue value)
    {
      _input.Entity.ReplaceCursorPosition(_cursorLastPosition);
      _input.Entity.isWalkingProvided = true;
    }

    public void OnGrantDestination(InputValue value)
    {
      _input.Entity.ReplaceWalkablePoint(Position(_cursorLastPosition));
      _input.Entity.isDestinationGranted = true;
    }

    public void OnInteract(InputValue value)
    {
      GameEntity targetEntity = PointedEntity();
      if(targetEntity == null)
        return;
      
      _input.Entity.ReplaceTargetId(targetEntity.Id);
      _input.Entity.isInteracted = true;
    }

    private GameEntity PointedEntity() => 
      _physics.RaycastHitEntity(_cursorLastPosition, _camera.Entity.MainCamera);

    private Vector3 Position(Vector2 value) => 
      _physics.RaycastHitPosition(origin: value, with: _camera.Entity.MainCamera);
  }
}