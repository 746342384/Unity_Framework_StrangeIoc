using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Battle.Character.Weapon
{
    public class BezierSpline : MonoBehaviour
    {
        public List<Transform> points;
        public Transform BezierPoint;
        public Color LineColor;

        private void Awake()
        {
            LineColor.a = 255;
            BezierPoint = TransformDeepFind.FindDeepChild(transform, nameof(BezierPoint));
            points = BezierPoint.GetComponentsInChildren<Transform>().ToList();
        }

        private void OnDrawGizmos()
        {
            DrawCurveInSceneView();
        }

        private void DrawCurveInSceneView()
        {
            Gizmos.color = LineColor;
            for (var i = 0; i < points.Count - 1; i++)
            {
                var rayOrigin = points[i].position;
                var rayNext = points[i + 1].position;
                Gizmos.DrawLine(rayOrigin, rayNext);
            }
        }
    }
}