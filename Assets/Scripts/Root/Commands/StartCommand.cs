using strange.extensions.command.impl;
using UnityEngine;

namespace Root.Commands
{
    public class StartCommand : EventCommand
    {
        public override void Execute()
        {
            Debug.Log("StartCommand.Execute");
        }
    }
}