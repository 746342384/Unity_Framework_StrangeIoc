using framework.framework.ui.api;

namespace framework.framework.ui.impl
{
    public abstract class UIPanel : IUIPanel
    {
        public abstract string PanelName { get; }
        public abstract string Path { get; }
        public abstract string ContextNmae { get; }
        public virtual UILayer Layer => UILayer.Normal;

        public void Show()
        {
            OnShow();
        }

        protected virtual void OnShow()
        {
        }

        public void Hide()
        {
            OnHide();
        }

        public virtual void UnLoad()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}