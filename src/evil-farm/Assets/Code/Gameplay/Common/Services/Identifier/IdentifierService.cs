namespace Code.Gameplay.Common.Services.Identifier
{
  public class IdentifierService : IIdentifierService
  {
    private int _lastId = 1;
    
    public int NextId() => 
      _lastId++;
  }
}