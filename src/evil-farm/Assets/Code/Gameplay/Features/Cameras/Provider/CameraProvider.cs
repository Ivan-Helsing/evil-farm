using Code.Gameplay.Features.Cameras.Factory;

namespace Code.Gameplay.Features.Cameras.Provider
{
  public class CameraProvider : ICameraProvider, ICameraBinder
  {
    private GameEntity _camera;
    public GameEntity Entity => _camera;
    
    private readonly ICameraFactory _factory;

    public CameraProvider(ICameraFactory factory) => 
      _factory = factory;

    public void Setup(int ownerId)
    {
      _camera = _factory.CreateCamera();
      _camera.AddOwnerId(ownerId);
    }

    public void Cleanup() =>
      _camera = null;
  }
}