using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Cameras.Systems
{
  public class CameraFollowSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _cameras;

    public CameraFollowSystem(GameContext game)
    {
      _game = game;
      _cameras = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.MainCamera,
          GameMatcher.Offset,
          GameMatcher.AngleX,
          GameMatcher.Distance,
          GameMatcher.Transform,
          GameMatcher.OwnerId));
    }

    public void Execute()
    {
      foreach (GameEntity camera in _cameras)
      {
        GameEntity target = _game.GetEntityWithId(camera.OwnerId);
        Vector3 targetPosition = target.Transform.position;

        Vector3 position = new Vector3(targetPosition.x, targetPosition.y + camera.Distance, targetPosition.z + camera.Offset);
        Quaternion rotation = Quaternion.Euler(camera.AngleX, 0f, 0f);

        camera.Transform.position = position;
        camera.Transform.rotation = rotation;
      }
    }
  }
}