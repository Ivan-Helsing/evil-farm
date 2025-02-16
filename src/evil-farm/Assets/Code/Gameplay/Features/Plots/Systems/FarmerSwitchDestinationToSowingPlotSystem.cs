using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Plots.Systems
{
  public class FarmerSwitchDestinationToSowingPlotSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _plots;
    private readonly List<GameEntity> _buffer = new (8);

    public FarmerSwitchDestinationToSowingPlotSystem(GameContext game)
    {
      _game = game;
      _plots = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Plot,
          GameMatcher.GrowPlant,
          GameMatcher.GrowingTimer,
          GameMatcher.GrowingDuration,
          GameMatcher.ReadyToAppointDestination));
    }

    public void Execute()
    {
      foreach (GameEntity plot in _plots.GetEntities(_buffer))
      {
        GameEntity farmer = _game.GetEntityWithId(plot.TargetId);
        
        if(farmer.isMovingToSowThePlot) 
          return;
        
        farmer.ReplaceDestinationPoint(plot.WorldPosition);
        farmer.isMovingToSowThePlot = true;
        farmer.isMoving = true;
        
        plot.isReadyToBeSowed = true;
        plot.isReadyToAppointDestination = false;
      }
    }
  }
}