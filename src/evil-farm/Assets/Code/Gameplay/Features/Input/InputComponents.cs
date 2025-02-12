using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Input
{
  [Game] public class Input : IComponent {}
  [Game] public class WalkingProvided : IComponent {}
  [Game] public class Interacted : IComponent {}
  [Game] public class DestinationGranted : IComponent {}
  
  [Game] public class CursorPosition : IComponent { public Vector2 Value; }
  [Game] public class WalkablePoint : IComponent { public Vector3 Value; }
  [Game] public class DestinationPoint : IComponent { public Vector3 Value; }
  
  [Game] public class InteractedTargetId : IComponent { public int Value; }
  
  [Game] public class ReadyToCleanup : IComponent {}
}