using System.Threading.Tasks;
using Framework.framework.system.api;

namespace framework.framework.ui.api
{
    public interface IPanelSystem : ISystem
    {
        bool IsInitialized { get; set; }
        void OpenPanel(string panelName, object data = null);
        Task OpenPanelAsync(string panelName, object data = null);
        void ClosePanel(string panelName);
        Task ClosePanelAsync(string panelName);
        void UnLoadAllPanel();
        void UnLoadPanel(string panelName);
    }
}