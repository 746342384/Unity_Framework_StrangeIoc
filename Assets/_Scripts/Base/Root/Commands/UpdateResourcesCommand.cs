using Framework.framework.addressable.api;
using Module.Start;
using strange.extensions.command.impl;
using UnityEngine;

namespace Root.Commands
{
    public class UpdateResourcesCommand : EventCommand
    {
        [Inject] public IAddressableDownload AddressableDownload { get; set; }

        public override async void Execute()
        {
            Debug.Log("StartCommand.Execute");
            await AddressableDownload.StartPreDownload();
            Dispatcher.Dispatch(StartEvent.PreLoadResources);
        }
    }
}