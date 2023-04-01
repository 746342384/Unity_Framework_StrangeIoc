using Base.UI;
using framework.framework.ui.api;
using strange.extensions.command.impl;

namespace Root.Commands
{
    public class PreLoadResourcesCommand : EventCommand
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override async void Execute()
        {
            await PanelSystem.PreLoadPanel();
            await PanelSystem.OpenPanelAsync(PanelNames.StartPanel);
        }
    }
}