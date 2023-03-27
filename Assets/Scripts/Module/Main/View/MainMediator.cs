using Framework.framework.ui.mediator.impl;

namespace Module.Main.View
{
    public class MainMediator : UGameMediator<MainView>
    {
        [Inject] public MainView View { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.BackBtn.onClick.AddListener(() => { Dispatcher.Dispatch(MainEvent.Back); });
        }
    }
}