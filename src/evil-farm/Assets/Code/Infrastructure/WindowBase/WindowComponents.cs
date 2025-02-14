using Entitas;

namespace Code.Infrastructure.WindowBase
{
  [Game] public class PlantWindow : IComponent { }
  
  [Game] public class WindowId : IComponent { public WindowTypeId Value; }
  [Game] public class MenuId : IComponent { public int Value; }
  [Game] public class ParentId : IComponent { public int Value; }
  
}