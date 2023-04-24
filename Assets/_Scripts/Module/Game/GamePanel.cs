using Base.UI;
using Framework.framework.attribute;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Root;

namespace Module.Game
{
    [Act(typeof(IUIPanel), PanelNames.GamePanel)]
    public class GamePanel : UIPanel
    {
        public override string PanelName => PanelNames.GamePanel;
        public override string Path => PanelPath.GamePanel;
        public override string ContextNmae => ContextName.GameContext;
        public override UILayer Layer => UILayer.Normal;
    }
}