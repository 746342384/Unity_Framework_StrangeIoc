using framework.framework.ui.api;
using Framework.framework.ui.mediator.impl;

namespace Module.Main.View
{
    public class MainMediator : UGameMediator<MainView>
    {
        [Inject] public IPanelSystem PanelSystem { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.BackBtn.onClick.AddListener(() => { Dispatcher.Dispatch(MainEvent.Back); });
            View.RealeaseAllPanelBtn.onClick.AddListener(() => { PanelSystem.UnLoadAllPanel(); });
        }
    }
}