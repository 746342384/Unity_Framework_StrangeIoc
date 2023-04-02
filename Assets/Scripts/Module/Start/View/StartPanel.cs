using Base.UI;
using Framework.framework.attribute;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Root;

namespace Module.Start.View
{
    [Act(typeof(IUIPanel), PanelNames.StartPanel)]
    public class StartPanel : UIPanel
    {
        public override string PanelName => PanelNames.StartPanel;
        public override string Path => PanelPath.StartPanel;
        public override string ContextNmae => ContextName.GameContext;
        public override UILayer Layer => UILayer.Normal;
    }
}