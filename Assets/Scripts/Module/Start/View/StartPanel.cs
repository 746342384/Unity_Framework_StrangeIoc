using Base.UI;
using Framework.framework.attribute.api;
using framework.framework.ui.api;
using framework.framework.ui.impl;
using Root;
using UnityEngine;

namespace Module.Start.View
{
    [Act(typeof(IUIPanel), PanelNames.StartPanel)]
    public class StartPanel : UIPanel
    {
        public override string PanelName => PanelNames.StartPanel;
        public override string Path => PanelPath.StartPanel;
        public override string ContextNmae => ContextName.GameContext;
        public override UILayer Layer => UILayer.Normal;

        protected override void OnShow()
        {
            Debug.Log($"{nameof(Show)}{PanelNames.StartPanel}");
        }

        protected override void OnHide()
        {
            Debug.Log($"{nameof(Hide)}{PanelNames.StartPanel}");
        }
    }
}