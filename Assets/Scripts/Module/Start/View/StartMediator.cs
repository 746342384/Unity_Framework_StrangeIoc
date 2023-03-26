using Framework.framework.ui.mediator.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace Module.Start.View
{
    public class StartMediator : UGameMediator
    {
        [Inject(ContextKeys.CONTEXT_DISPATCHER)]
        public IEventDispatcher Dispatcher { get; set; }

        [Inject] public StartView View { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            Dispatcher.AddListener(StartEvent.Start, OnStart);
            View.Button.onClick.AddListener(() => { Dispatcher.Dispatch(StartEvent.Start, "OnStart"); });
        }

        private void OnStart(IEvent payload)
        {
            Debug.Log(payload.data.ToString());
        }
    }
}