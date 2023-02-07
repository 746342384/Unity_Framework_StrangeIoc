using System.Threading.Tasks;

namespace framework.framework.ui.api
{
    public interface IPanelSystem
    {
        bool IsInitialized { get; set; }
        void Init();
        void OpenPanel(string panelName, object data = null);
        Task OpenPanelAsync(string panelName, object data = null);
        void ClosePanel(string panelName);
        Task ClosePanelAsync(string panelName);
    }
}