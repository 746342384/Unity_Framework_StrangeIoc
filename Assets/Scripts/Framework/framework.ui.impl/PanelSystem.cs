using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.framework.resources.api;
using framework.framework.ui.api;

namespace framework.framework.ui.impl
{
    public class PanelSystem : IPanelSystem
    {
        private readonly IResourceSystemService _resourceSystemService;
        private List<IUIPanel> _panels;

        public PanelSystem(IResourceSystemService resourceSystemService)
        {
            _resourceSystemService = resourceSystemService;
        }

        public bool IsInitialized { get; set; }

        public void Init()
        {
            if (IsInitialized) return;
            _panels = new List<IUIPanel>();
            LoadPanels();
            IsInitialized = true;
        }

        private void LoadPanels()
        {
            
        }

        public void OpenPanel(string panelName, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public Task OpenPanelAsync(string panelName, object data = null)
        {
            throw new System.NotImplementedException();
        }

        public void ClosePanel(string panelName)
        {
            throw new System.NotImplementedException();
        }

        public Task ClosePanelAsync(string panelName)
        {
            throw new System.NotImplementedException();
        }
    }
}