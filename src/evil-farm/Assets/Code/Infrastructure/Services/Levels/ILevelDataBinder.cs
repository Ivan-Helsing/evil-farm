using UnityEngine;

namespace Code.Infrastructure.Services.Levels
{
  public interface ILevelDataBinder
  {
    void BindInitialPoint(Vector3 initialPoint);
  }
}