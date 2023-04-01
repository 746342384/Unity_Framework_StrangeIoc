using System.Collections;
using Framework.framework.coroutine.api;
using UnityEngine;

namespace Framework.framework.coroutine.impl
{
    public class CoroutineSystem : ICoroutineSystem
    {
        private CoroutineRunner _coroutineRunner;

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return _coroutineRunner.StartCoroutine(coroutine);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            _coroutineRunner.StopCoroutine(coroutine);
        }

        public void StopAllCoroutine()
        {
            _coroutineRunner.StopAllCoroutines();
        }

        public void OnInit()
        {
            var o = new GameObject("[CoroutineRunner]");
            _coroutineRunner = o.AddComponent<CoroutineRunner>();
            Object.DontDestroyOnLoad(o);
        }
    }
}