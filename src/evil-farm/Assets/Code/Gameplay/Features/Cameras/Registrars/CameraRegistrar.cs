using Code.Infrastructure.Entities.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Cameras.Registrars
{
  public class CameraRegistrar : EntityComponentRegistrar
  {
    public Camera Camera;

    public override void RegisterComponents() => 
      Entity.AddMainCamera(Camera);

    public override void UnregisterComponents()
    {
      if(Entity.hasMainCamera)
        Entity.RemoveMainCamera();
    }
  }
}