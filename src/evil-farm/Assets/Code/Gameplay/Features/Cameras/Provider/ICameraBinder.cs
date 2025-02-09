namespace Code.Gameplay.Features.Cameras.Provider
{
  public interface ICameraBinder
  {
    void Setup(int ownerId);
    void Cleanup();
  }
}