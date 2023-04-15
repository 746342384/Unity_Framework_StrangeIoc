using System;
using UnityEngine;
using System.Collections.Generic;

namespace Battle.Character.Player.Weapon
{
    public class BezierSpline : MonoBehaviour
    {
        /// <summary>
        /// Bezier曲线的控制点
        /// </summary>
        public List<Transform> points;

        public int resolution = 100; // 曲线的分辨率
        public Color LineColor;

        private void Awake()
        {
            LineColor.a = 255;
        }

        public Vector3 GetPoint(float t)
        {
            // 使用Cubic Bezier公式计算位置
            return (1 - t) * (1 - t) * (1 - t) * points[0].position + 3 * (1 - t) * (1 - t) * t * points[1].position +
                   3 * (1 - t) * t * t * points[2].position + t * t * t * points[3].position;
        }

        void OnDrawGizmos()
        {
            DrawCurveInSceneView();
        }
        
        private void DrawCurveInSceneView()
        {
            Gizmos.color = LineColor;
            for (var i = 0; i < resolution; i++)
            {
                var t1 = (float)i / resolution;
                var t2 = (float)(i + 1) / resolution;

                var startPoint = GetPoint(t1);
                var endPoint = GetPoint(t2);

                // 在Scene视图中绘制线段，便于调试（游戏运行时不会显示）
                Gizmos.DrawLine(startPoint, endPoint);
            }
        }
    }
}