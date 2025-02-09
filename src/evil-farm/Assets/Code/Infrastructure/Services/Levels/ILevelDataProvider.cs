using UnityEngine;

namespace Code.Infrastructure.Services.Levels
{
  public interface ILevelDataProvider
  {
    Vector3 InitialPoint { get; }
  }
}