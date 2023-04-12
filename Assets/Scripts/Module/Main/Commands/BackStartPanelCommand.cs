using Base.UI;
using framework.framework.ui.api;
using strange.extensions.command.impl;

namespace Module.Main.Commands
{
    public class BackStartPanelCommand : EventCommand
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override void Execute()
        {
            base.Execute();
            PanelSystem.ClosePanel(PanelNames.MainPanel);
            //PanelSystem.OpenPanel(PanelNames.StartPanel);
        }
    }
}