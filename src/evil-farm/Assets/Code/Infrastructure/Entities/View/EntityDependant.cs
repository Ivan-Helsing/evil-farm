using UnityEngine;

namespace Code.Infrastructure.Entities.View
{
  public class EntityDependant : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour EntityView;
    
    protected GameEntity Entity => EntityView != null ? EntityView.Entity : null;

    private void Awake()
    {
      if (!EntityView)
        EntityView = gameObject.GetComponent<EntityBehaviour>();
    }
  }
}