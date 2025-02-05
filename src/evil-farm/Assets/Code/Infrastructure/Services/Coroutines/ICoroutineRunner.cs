using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.Services.Coroutines
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator routine);
  }
}