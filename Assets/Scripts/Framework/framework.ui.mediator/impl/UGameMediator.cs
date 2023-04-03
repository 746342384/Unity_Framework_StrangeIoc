using System;
using Framework.framework.ui.mediator.api;
using Framework.framework.ui.view.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Framework.framework.ui.mediator.impl
{
    public class UGameMediator<T> : Mediator, IGameMediator where T : UGameView
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher Dispatcher { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View = GetComponent<T>();
        }

        public T View { get; set; }
    }
}