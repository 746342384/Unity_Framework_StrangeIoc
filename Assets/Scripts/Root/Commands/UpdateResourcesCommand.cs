using Base.UI;
using Framework.framework.addressable.api;
using framework.framework.ui.api;
using strange.extensions.command.impl;
using UnityEngine;

namespace Root.Commands
{
    public class UpdateResourcesCommand : EventCommand
    {
        [Inject] public IAddressableDownload AddressableDownload { get; set; }
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override async void Execute()
        {
            Debug.Log("StartCommand.Execute");
            await AddressableDownload.StartPreload();
            await PanelSystem.OpenPanelAsync(PanelNames.StartPanel);
        }
    }
}