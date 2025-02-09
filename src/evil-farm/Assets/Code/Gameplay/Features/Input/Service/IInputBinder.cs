namespace Code.Gameplay.Features.Input.Service
{
  public interface IInputBinder
  {
    void Setup(int ownerId);
    void Cleanup(GameEntity entity);
  }
}