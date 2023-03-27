using Framework.framework.ui.mediator.impl;

namespace Module.Start.View
{
    public class StartMediator : UGameMediator<StartView>
    {
        public override void OnRegister()
        {
            base.OnRegister();
            View.Button.onClick.AddListener(() => { Dispatcher.Dispatch(StartEvent.Start); });
        }
    }
}