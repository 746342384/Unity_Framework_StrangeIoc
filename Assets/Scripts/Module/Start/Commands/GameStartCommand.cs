using strange.extensions.command.impl;
using UnityEngine;

namespace Module.Start.Commands
{
    public class GameStartCommand : EventCommand
    {
        public override void Execute()
        {
            Debug.Log(nameof(GameStartCommand));
        }
    }
}