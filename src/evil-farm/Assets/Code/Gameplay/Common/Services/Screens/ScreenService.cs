using UnityEngine;

namespace Code.Gameplay.Common.Services.Screens
{
  public class ScreenService : IScreenService
  {
    public Vector3 BindZeroToCenter(Vector2 vector2) => 
      new(vector2.x - CenterAxisX(), 0f, vector2.y - CenterAxisZ());

    public float CenterAxisX() => 
      Screen.width / 2;
    
    public float CenterAxisZ() => 
      Screen.height / 2;
  }
}