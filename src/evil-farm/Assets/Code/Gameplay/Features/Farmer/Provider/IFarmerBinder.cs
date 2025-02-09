namespace Code.Gameplay.Features.Farmer.Provider
{
  public interface IFarmerBinder
  {
    GameEntity Setup();
    void Cleanup();
  }
}