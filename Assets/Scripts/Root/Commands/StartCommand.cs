using Module.Start;
using strange.extensions.command.impl;

namespace Root.Commands
{
    public class StartCommand : EventCommand
    {
        public override void Execute()
        {
            Dispatcher.Dispatch(StartEvent.Update);
        }
    }
}