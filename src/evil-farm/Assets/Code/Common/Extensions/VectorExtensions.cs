using UnityEngine;

namespace Code.Common.Extensions
{
  public static class VectorExtensions
  {
    public static Vector3 AddY(this Vector3 vector) => 
      new(vector.x, vector.y + 0.5f, vector.z);
  }
}