using UnityEngine;

namespace Code.Gameplay.Features.Plots.Factory
{
  public interface IPlotsFactory
  {
    GameEntity CreatePlot(Vector3 at, Transform with);
  }
}