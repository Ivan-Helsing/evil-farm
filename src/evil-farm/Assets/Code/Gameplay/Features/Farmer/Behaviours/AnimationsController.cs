using Code.Infrastructure.Entities.View;
using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Behaviours
{
  public class AnimationsController : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityView;
    
    public void ChangingAnimationState()
    {
      _entityView.Entity.isCompletedAction = true;
      _entityView.Entity.isChangingAnimationState = true;
      
      _entityView.Entity.isPerformingAction = false;
    }
  }
}