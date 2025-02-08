using Code.Gameplay.Common.Services.Collisions;

namespace Code.Common.Extensions
{
  public static class CollisionExtensions
  {
    public static int AsLayer(this CollisionLayer layer) => 
      1<<(int)layer;
  }
}