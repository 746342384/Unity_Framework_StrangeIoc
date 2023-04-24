using UnityEngine;

namespace Extensions
{
    public static class GameObjectEx
    {
        public static void SetParent(this GameObject gameObject, Transform parent)
        {
            gameObject.transform.SetParent(parent);
        }

        public static void SetScale(this GameObject gameObject, Vector3 vector3)
        {
            gameObject.transform.localScale = vector3;
        }

        public static void SetPostion(this GameObject gameObject, Vector3 vector3)
        {
            gameObject.transform.position = vector3;
        }

        public static void SetLocalPostion(this GameObject gameObject, Vector3 vector3)
        {
            gameObject.transform.localPosition = vector3;
        }
    }
}