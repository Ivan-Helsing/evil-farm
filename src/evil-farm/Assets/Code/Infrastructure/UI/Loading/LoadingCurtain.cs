using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.UI.Loading
{
  public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
  {
    public CanvasGroup Canvas;
    
    public void Show()
    {
      gameObject.SetActive(true);
      Canvas.alpha = 1;
    }

    public void Hide() => 
      StartCoroutine(Fade());

    private IEnumerator Fade()
    {
      while (Canvas.alpha > 0)
      {
        Canvas.alpha -= 0.05f;
        yield return new WaitForFixedUpdate();
      }
      
      gameObject.SetActive(false);
    }
  }
}