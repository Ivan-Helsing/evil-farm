namespace Code.Gameplay.Features.Input.Service
{
  public interface IInputBinder
  {
    void SetupInputEntity(GameEntity entity);
    void CleanupInputEntity(GameEntity entity);
  }
}