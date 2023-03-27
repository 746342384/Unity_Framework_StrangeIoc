using framework.framework.ui.impl;

namespace framework.framework.ui.api
{
    public interface IUIPanel
    {
        string PanelName { get; }
        string Path { get; }
        UILayer Layer { get; }
        string ContextNmae { get; }

        void Show();
        void Hide();
        void UnLoad();
    }
}