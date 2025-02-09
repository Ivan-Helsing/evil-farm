using Entitas;

namespace Code.Gameplay.Features.Farmer.Systems
{
  public class DirectionProvidedFromDestinationPointSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _farmers;

    public DirectionProvidedFromDestinationPointSystem(GameContext game)
    {
      _farmers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.DestinationPoint));
    }

    public void Execute()
    {
      foreach (GameEntity farmer in _farmers)
      {
        farmer.ReplaceDirection(farmer.DestinationPoint - farmer.Transform.position);
      }
    }
  }
}