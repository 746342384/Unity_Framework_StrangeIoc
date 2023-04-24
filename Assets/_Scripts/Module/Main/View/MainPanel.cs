using Base.UI;
using Framework.framework.attribute;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Root;

namespace Module.Main.View
{
    [Act(typeof(IUIPanel), PanelNames.MainPanel)]
    public class MainPanel : UIPanel
    {
        public override string PanelName => PanelNames.MainPanel;
        public override string Path => PanelPath.MainPanel;
        public override string ContextNmae => ContextName.GameContext;
        public override UILayer Layer => UILayer.Normal;
    }
}