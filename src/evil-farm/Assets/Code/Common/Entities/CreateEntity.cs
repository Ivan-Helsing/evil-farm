namespace Code.Common.Entities
{
  public static class CreateEntity
  {
    public static GameEntity Empty() => 
      Contexts.sharedInstance.game.CreateEntity();
  }
}