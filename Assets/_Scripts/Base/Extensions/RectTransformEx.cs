using UnityEngine;

namespace Extensions
{
    public static class RectTransformEx
    {
        private static readonly RectOffset ZeroRectOffset = new RectOffset(0, 0, 0, 0);

        public static void FitParent(this RectTransform rectTransform)
        {
            rectTransform.FitParent(ZeroRectOffset);
        }

        public static void FitParent(this RectTransform rectTransform, RectOffset offset)
        {
            rectTransform.SetInsetAndSizeFromParentEdge(0, 0f, 0f);
            rectTransform.SetInsetAndSizeFromParentEdge((RectTransform.Edge) 2, 0f, 0f);
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMax = new Vector2(offset.right, offset.top);
            rectTransform.offsetMin = new Vector2(offset.left, offset.bottom);
        }

        public static void FixedSize(this RectTransform rectTransform, Vector2 size)
        {
            rectTransform.anchorMin = Vector2.one / 2f;
            rectTransform.anchorMax = Vector2.one / 2f;
            rectTransform.SetSizeWithCurrentAnchors(0, size.x);
            rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, size.y);
        }

        public static void FitTop(this RectTransform rectTransform, float height)
        {
            rectTransform.SetSizeWithCurrentAnchors(0, 0f);
            rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, height);
            rectTransform.anchorMin = new Vector2(0f, 1f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.pivot = new Vector2(0.5f, 0f);
            rectTransform.anchoredPosition = new Vector2(0f, 0f);
        }

        public static void FitBottom(this RectTransform rectTransform, float height)
        {
            rectTransform.SetSizeWithCurrentAnchors(0, 0f);
            rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, height);
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 0f);
            rectTransform.pivot = new Vector2(0.5f, 1f);
            rectTransform.anchoredPosition = new Vector2(0f, 0f);
        }

        public static void FitLeft(this RectTransform rectTransform, float weight)
        {
            rectTransform.SetSizeWithCurrentAnchors(0, weight);
            rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 0f);
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.pivot = new Vector2(1f, 0.5f);
            rectTransform.anchoredPosition = new Vector2(0f, 0f);
        }

        public static void FitRight(this RectTransform rectTransform, float weight)
        {
            rectTransform.SetSizeWithCurrentAnchors(0, weight);
            rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 0f);
            rectTransform.anchorMin = new Vector2(1f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.pivot = new Vector2(0f, 0.5f);
            rectTransform.anchoredPosition = new Vector2(0f, 0f);
        }
    }
}