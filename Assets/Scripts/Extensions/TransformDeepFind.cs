using System.Collections.Generic;
using UnityEngine;

public static class TransformDeepFind
{
    // 根据名称深度查找子物体
    public static Transform FindDeepChild(Transform parent, string name)
    {
        Transform result = null;

        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }
            else
            {
                result = FindDeepChild(child, name);
                if (result != null)
                {
                    return result;
                }
            }
        }

        return result;
    }

    // 根据类型深度查找组件
    public static T FindDeepComponent<T>(Transform parent) where T : Component
    {
        var component = parent.GetComponent<T>();

        if (component != null)
        {
            return component;
        }

        foreach (Transform child in parent)
        {
            component = FindDeepComponent<T>(child);
            if (component != null)
            {
                return component;
            }
        }

        return null;
    }

    // 根据类型深度查找组件
    public static List<T> FindDeepComponents<T>(Transform parent) where T : Component
    {
        var list = new List<T>();
        var components = parent.GetComponents<T>();
        list.AddRange(components);
        foreach (Transform child in parent)
        {
            var component = FindDeepComponents<T>(child);
            list.AddRange(component);
        }
        return list;
    }
}