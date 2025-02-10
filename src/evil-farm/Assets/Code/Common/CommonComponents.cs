﻿using Code.Infrastructure.Entities.View;
using Entitas;
using UnityEngine;

namespace Code.Common
{
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class ViewPath : IComponent { public string Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class Parent : IComponent { public Transform Value; }

  [Game] public class Destructed : IComponent {}
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
}