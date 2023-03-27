using Base.UI;
using framework.framework.ui.api;
using strange.extensions.command.impl;

namespace Module.Start.Commands
{
    public class GameStartCommand : EventCommand
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override void Execute()
        {
            PanelSystem.ClosePanel(PanelNames.StartPanel);
            PanelSystem.OpenPanel(PanelNames.MainPanel);
        }
    }
}