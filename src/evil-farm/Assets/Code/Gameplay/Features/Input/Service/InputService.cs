namespace Code.Gameplay.Features.Input.Service
{
  public class InputService : IInputService, IInputBinder
  {
    private GameEntity _entity;
    public GameEntity Entity => _entity;

    public void SetupInputEntity(GameEntity entity) =>
      _entity = entity;

    public void CleanupInputEntity(GameEntity entity) =>
      _entity = null;
  }
}