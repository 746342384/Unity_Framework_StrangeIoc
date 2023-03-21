using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.framework.resources.api;
using framework.framework.ui.api;

namespace framework.framework.ui.impl
{
    public class PanelSystem : IPanelSystem
    {
        private readonly IResourceSystemService _resourceSystemService;
        private readonly IUIRoot _uiRoot;
        private List<IUIPanel> _panels;

        public PanelSystem(IResourceSystemService resourceSystemService,
            IUIRoot uiRoot)
        {
            _resourceSystemService = resourceSystemService;
            _uiRoot = uiRoot;
            OnInit();
        }

        public bool IsInitialized { get; set; }

        public void OnInit()
        {
            if (IsInitialized) return;
            _uiRoot.Init();
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