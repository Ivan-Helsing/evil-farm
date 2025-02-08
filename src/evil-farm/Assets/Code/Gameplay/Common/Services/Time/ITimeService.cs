namespace Code.Gameplay.Common.Services.Time
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    void StopTime();
    void StartTime();
  }
}