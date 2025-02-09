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
          GameMatcher.RotationAngleX,
          GameMatcher.Distance,
          GameMatcher.Transform,
          GameMatcher.OwnerId));
    }

    public void Execute()
    {
      foreach (GameEntity camera in _cameras)
      {
        GameEntity target = _game.GetEntityWithId(camera.OwnerId);
        
        Quaternion rotation = Quaternion.Euler(camera.RotationAngleX, 0f, 0f);
        Vector3 position = rotation * new Vector3(0, 0, -camera.Distance) + PositionOffset(target, camera);

        camera.Transform.position = position;
        camera.Transform.rotation = rotation;
      }
    }

    private Vector3 PositionOffset(GameEntity target, GameEntity camera)
    {
      Vector3 followingPosition = target.Transform.position;
      followingPosition.y += camera.Offset;
      return followingPosition;
    }
  }
}