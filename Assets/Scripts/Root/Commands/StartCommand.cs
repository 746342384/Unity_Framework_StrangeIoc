using framework.framework.ui.api;
using strange.extensions.command.impl;
using UnityEngine;

namespace Root.Commands
{
    public class StartCommand : EventCommand
    {

        [Inject] public IUIRoot UIRoot { get; set; }

        public override void Execute()
        {
            Debug.Log("StartCommand.Execute");
            UIRoot.Init();
        }
    }
}