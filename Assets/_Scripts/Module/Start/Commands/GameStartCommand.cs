using Base.UI;
using framework.framework.ui.api;
using strange.extensions.command.impl;

namespace Module.Start.Commands
{
    public class GameStartCommand : EventCommand
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override async void Execute()
        {
            await PanelSystem.OpenPanelAsync(PanelNames.MainPanel);
            await PanelSystem.ClosePanelAsync(PanelNames.StartPanel);
        }
    }
}