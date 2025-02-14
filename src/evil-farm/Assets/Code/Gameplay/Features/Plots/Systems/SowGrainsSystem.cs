using Entitas;

namespace Code.Gameplay.Features.Plots.Systems
{
  public class SowGrainsSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _plantWindow;

    public SowGrainsSystem(GameContext game)
    {
      _game = game;
      _plantWindow = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.ParentId,
          GameMatcher.GrowPlant,
          GameMatcher.PlantWindow));
    }

    public void Execute()
    {
      foreach (GameEntity window in _plantWindow)
      {
        GameEntity plot = _game.GetEntityWithId(window.ParentId);
        plot.AddGrowPlant(window.GrowPlant);

        plot.RemoveMenuId();
        window.isDestructed = true;
      }
    }
  }
}