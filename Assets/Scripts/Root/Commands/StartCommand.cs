using Base.UI;
using framework.framework.ui.api;
using strange.extensions.command.impl;
using UnityEngine;

namespace Root.Commands
{
    public class StartCommand : EventCommand
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override async void Execute()
        {
            Debug.Log("StartCommand.Execute");
            await PanelSystem.OpenPanelAsync(PanelNames.StartPanel);
        }
    }
}