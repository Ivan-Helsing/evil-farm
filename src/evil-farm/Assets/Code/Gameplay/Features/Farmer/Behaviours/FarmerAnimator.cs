using System;
using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Behaviours
{
  public class FarmerAnimator : MonoBehaviour
  {
    private readonly int _isMovingHash = Animator.StringToHash("Moving");
    private readonly int _isInAction = Animator.StringToHash("InAction");
    private readonly int _performingSowHash = Animator.StringToHash("PerformingSow");
    private readonly int _harvestingHash = Animator.StringToHash("Harvesting");
    
    [SerializeField] private Animator _animator;

    public void Play(AnimationTypeId animation)
    {
      switch (animation)
      {
        case AnimationTypeId.Idle:
          ResetAllToIdle();
          break;
        case AnimationTypeId.Run:
          PlayMoving();
          break;
        case AnimationTypeId.Harvest:
          PlayHarvesting();
          break;
        case AnimationTypeId.Sow:
          PlaySowing();
          break;
      }
      throw new Exception("Unknown animation type");
    }

    private void PlayMoving() => _animator.SetBool(_isMovingHash, true);

    private void ResetAllToIdle()
    {
      _animator.SetBool(_isInAction, false);
      _animator.SetBool(_isMovingHash, false);
    }

    private void PlaySowing()
    {
      _animator.SetBool(_isInAction, true);
      _animator.SetTrigger(_performingSowHash);
    }

    private void PlayHarvesting()
    {
      _animator.SetBool(_isInAction, true);
      _animator.SetTrigger(_harvestingHash);
    }
  }
}