using System;
using UnityEngine;
using System.Collections;

public class ErrorDisplay : MonoBehaviour
{
    internal void OnEnable()
    {
        Application.RegisterLogCallback(HandleLog);
        Debug.LogError($"TEST");
    }

    internal void OnDisable()
    {
        Application.RegisterLogCallback(null);
    }

    private string m_logs;

    /// <summary>
    /// 
    /// /// </summary>    
    /// /// <param name="logString">错误信息</param>    /// 
    /// <param name="stackTrace">跟踪堆栈</param>    /// 
    /// <param name="type">错误类型</param>    
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Exception:
            case LogType.Error:
            case LogType.Assert:
                m_logs += $"<color #FF0000>{logString}</color>"+"\n";
                break;
            case LogType.Warning:
                m_logs += $"<color #FFFF00>{logString}</color>"+"\n";
                break;
            case LogType.Log:
                m_logs += $"<color #000000>{logString}</color>"+"\n";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public bool Log;
    private Vector2 m_scroll;

    internal void OnGUI()
    {
        if (GUILayout.Button("Log"))
        {
            Log = !Log;
        }

        if (!Log)
            return;
        m_scroll = GUILayout.BeginScrollView(m_scroll);
        GUIStyle a = new GUIStyle
        {
            fontSize = 10
        };
        GUILayout.Label(m_logs, a);
        GUILayout.EndScrollView();
    }
}