using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Cameras
{
  [Game] public class MainCamera : IComponent { public Camera Value; }
  
  [Game] public class Distance : IComponent { public float Value; }
  [Game] public class Offset : IComponent { public float Value; }
  [Game] public class RotationAngleX : IComponent { public float Value; }
}