namespace Code.Gameplay.Features.Farmer.Provider
{
  public interface IFarmerBinder
  {
    void BindFarmerEntity(GameEntity farmer);
    void CleanupFarmerEntity();
  }
}