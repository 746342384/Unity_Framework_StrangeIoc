using System.Collections;
using Framework.framework.system.api;
using UnityEngine;

namespace Framework.framework.coroutine.api
{
    public interface ICoroutineSystem : ISystem
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
        void StopAllCoroutine();
    }
}