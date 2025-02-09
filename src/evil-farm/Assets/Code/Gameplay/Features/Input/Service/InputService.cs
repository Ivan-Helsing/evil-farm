using Code.Gameplay.Features.Input.Factory;

namespace Code.Gameplay.Features.Input.Service
{
  public class InputService : IInputService, IInputBinder
  {
    private GameEntity _input;
    public GameEntity Entity => _input;

    private readonly IInputFactory _factory;

    public InputService(IInputFactory factory) => 
      _factory = factory;

    public void Setup(int ownerId)
    {
      _input = _factory.CreateInput();
      _input.AddOwnerId(ownerId);
    }

    public void Cleanup(GameEntity entity) =>
      _input = null;
  }
}