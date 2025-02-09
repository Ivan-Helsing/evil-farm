using UnityEngine;

namespace Code.Gameplay.Features.Movement.Behaviours
{
  public interface ICharacterMover
  {
    void Move(Vector3 direction, float speed);
  }
}