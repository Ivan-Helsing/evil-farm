using Code.Gameplay.Features.Movement.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
  [Game] public class Moving : IComponent {}
  [Game] public class MovementAvailable : IComponent {}
  [Game] public class ReadyToAppointDestination : IComponent {}
  [Game] public class MovingToSowThePlot : IComponent {}
  
  [Game] public class Speed : IComponent { public float Value; }
  [Game] public class Direction : IComponent { public Vector3 Value; }
  
  [Game] public class CharacterMoverComponent : IComponent { public ICharacterMover Value; }
}