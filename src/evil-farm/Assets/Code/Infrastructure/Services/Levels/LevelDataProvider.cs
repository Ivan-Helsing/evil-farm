using UnityEngine;

namespace Code.Infrastructure.Services.Levels
{
  public class LevelDataProvider : ILevelDataProvider, ILevelDataBinder
  {
    private Vector3 _initPoint;
    public Vector3 InitialPoint => _initPoint;

    public void BindInitialPoint(Vector3 initialPoint) => 
      _initPoint = initialPoint;
  }
}