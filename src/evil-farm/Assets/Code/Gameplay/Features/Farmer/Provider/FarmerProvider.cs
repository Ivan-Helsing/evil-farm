namespace Code.Gameplay.Features.Farmer.Provider
{
  public class FarmerProvider : IFarmerBinder, IFarmerProvider
  {
    private GameEntity _entity;
    public GameEntity Entity => _entity;

    public void BindFarmerEntity(GameEntity farmer) =>
      _entity = farmer;

    public void CleanupFarmerEntity() =>
      _entity = null;
  }
}