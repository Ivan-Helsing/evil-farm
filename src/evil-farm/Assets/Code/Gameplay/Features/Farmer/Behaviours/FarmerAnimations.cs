using Code.Infrastructure.Entities.View;
using UnityEngine;

namespace Code.Gameplay.Features.Farmer.Behaviours
{
  public class FarmerAnimations : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityView;
    
    public void ChangingAnimationState() => 
      _entityView.Entity.isChangingAnimationState = true;
  }
}