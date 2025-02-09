using Code.Gameplay.Common.Services.Physics;
using Code.Gameplay.Common.Services.Time;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Movement.Behaviours
{
  public class CharacterMover : MonoBehaviour, ICharacterMover
  {
    [SerializeField] private CharacterController _controller;
    private IPhysicsService _physics;
    private ITimeService _time;

    [Inject]
    public void Construct(ITimeService time, IPhysicsService physics)
    {
      _time = time;
      _physics = physics;
    }
    
    public void Move(Vector3 direction, float speed)
    {
      Vector3 movementVector = direction;
      movementVector.Normalize();

      movementVector += _physics.Gravity;
      _controller.Move(movementVector * speed * _time.DeltaTime);
    }
  }
}