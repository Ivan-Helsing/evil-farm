﻿using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Services.SystemFactory;

namespace Code.Gameplay.Features.Movement
{
  public sealed class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systems)
    {
      Add(systems.Create<CharacterMovingSystem>());
      Add(systems.Create<DestinationRemovingOnReachingPointSystem>());
      Add(systems.Create<DestinationRemovingOnReachingPlotSystem>());
      
      Add(systems.Create<WorldPositionUpdatingSystem>());
    }
  }
}