using Framework.framework.ui.mediator.impl;

namespace Module.Main.View
{
    public class MainMediator : UGameMediator<MainView>
    {
        public override void OnRegister()
        {
            base.OnRegister();
            View.BackBtn.onClick.AddListener(() => { Dispatcher.Dispatch(MainEvent.Back); });
        }
    }
}