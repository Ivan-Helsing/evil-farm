using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Behaviours
{
  public class FarmerAnimator : MonoBehaviour
  {
    private readonly int _isMovingHash = Animator.StringToHash("isMoving");
    private readonly int _performingSowHash = Animator.StringToHash("PerformingSow");
    private readonly int _harvestingHash = Animator.StringToHash("Harvesting");
    
    [SerializeField] private Animator _animator;

    public void ResetAllToIdle() => _animator.SetBool(_isMovingHash, false);
    public void PlayMoving() => _animator.SetBool(_isMovingHash, true);
    public void PlaySowing() => _animator.SetBool(_performingSowHash, true);
    public void PlayHarvesting() => _animator.SetBool(_harvestingHash, true);
  }
}