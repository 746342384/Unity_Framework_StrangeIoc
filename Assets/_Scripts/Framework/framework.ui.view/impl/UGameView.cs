using Framework.framework.ui.view.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Framework.framework.ui.view.impl
{
    public class UGameView : View, IGameView
    {
        [Inject] public IEventDispatcher Dispatcher { get; set; }
        public override bool autoRegisterWithContext { get; set; } = true;
    }
}