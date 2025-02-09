using Code.Gameplay.Features.Farmer.Factory;
using Code.Infrastructure.Services.Levels;

namespace Code.Gameplay.Features.Farmer.Provider
{
  public class FarmerProvider : IFarmerBinder, IFarmerProvider
  {
    private GameEntity _farmer;
    public GameEntity Entity => _farmer;

    private readonly IFarmerFactory _factory;
    private readonly ILevelDataProvider _levelDataProvider;

    public FarmerProvider(IFarmerFactory factory, ILevelDataProvider levelDataProvider)
    {
      _factory = factory;
      _levelDataProvider = levelDataProvider;
    }

    public GameEntity Setup() =>
      _farmer = _factory.Create(_levelDataProvider.InitialPoint);

    public void Cleanup() =>
      _farmer = null;
  }
}