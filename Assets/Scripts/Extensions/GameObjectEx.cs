using UnityEngine;

namespace Extensions
{
    public static class GameObjectEx
    {
        public static void SetParent(this GameObject gameObject, Transform parent)
        {
            gameObject.transform.SetParent(parent);
        }
    }
}