using Extensions;
using framework.framework.ui.api;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace framework.framework.ui.impl
{
    public class UIRoot : IUIRoot
    {
        public Transform Root { get; set; }
        public Transform NormalRoot { get; set; }
        public Transform TopRoot { get; set; }
        public Transform PopUpRoot { get; set; }
        public Camera UICamera { get; set; }
        public Canvas UICanvas { get; set; }

        public void Init()
        {
            CreateUIRoot();
            CreateUICamera();
            AddUICanvas();
            CreateChildRoot();
            CreateEventSystem();
        }

        private void CreateEventSystem()
        {
            var gameObject = new GameObject("EventSystem")
                { layer = LayerMask.NameToLayer("UI") };
            gameObject.SetParent(Root);
            gameObject.AddComponent<EventSystem>();
            gameObject.AddComponent<StandaloneInputModule>();
        }

        private void CreateUIRoot()
        {
            var gameObject = new GameObject("UIRoot")
            {
                layer = LayerMask.NameToLayer("UI"),
                transform =
                {
                    localPosition = Vector3.zero,
                    localRotation = Quaternion.identity,
                    localScale = Vector3.one
                }
            };
            gameObject.AddComponent<RectTransform>();
            Object.DontDestroyOnLoad(gameObject);
            Root = gameObject.transform;
        }

        private void CreateChildRoot()
        {
            NormalRoot = AddChildRoot("Normal", 0, "UI");
            TopRoot = AddChildRoot("Top", 200, "UI");
            PopUpRoot = AddChildRoot("PopUp", 150, "UI");
        }

        private Transform AddChildRoot(string name, int sort, string layerName)
        {
            var gameObject = new GameObject(name)
            {
                layer = LayerMask.NameToLayer("UI")
            };
            var root = gameObject.AddComponent<RectTransform>();
            root.transform.SetParent(Root);
            root.FitParent();
            var transform = root.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;

            var canvas = gameObject.gameObject.AddComponent<Canvas>();
            canvas.overrideSorting = true;
            canvas.sortingOrder = sort;
            canvas.sortingLayerName = layerName;

            gameObject.AddComponent<GraphicRaycaster>();
            return root.transform;
        }

        private void CreateUICamera()
        {
            var gameObject = new GameObject(nameof(UICamera));
            UICamera = gameObject.AddComponent<Camera>();
            gameObject.transform.SetParent(Root);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.localScale = Vector3.one;
            UICamera.clearFlags = CameraClearFlags.Depth;
            UICamera.cameraType = CameraType.SceneView;
            UICamera.backgroundColor = Color.black;
            gameObject.AddComponent<AudioListener>();
        }

        private void AddUICanvas()
        {
            UICanvas = Root.gameObject.AddComponent<Canvas>();
            UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            UICanvas.pixelPerfect = true;
            UICanvas.worldCamera = UICamera;
            UICanvas.sortingLayerName = "UI";
            UICanvas.sortingOrder = 0;
            Root.gameObject.AddComponent<GraphicRaycaster>();
            var canvasScaler = Root.gameObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
            canvasScaler.referenceResolution = new Vector2(720, 1280);
        }
    }
}