using UnityEngine;

namespace Code.Gameplay.Common.Services.Screens
{
  public interface IScreenService
  {
    Vector3 BindZeroToCenter(Vector2 vector2);
    float CenterAxisX();
    float CenterAxisZ();
  }
}