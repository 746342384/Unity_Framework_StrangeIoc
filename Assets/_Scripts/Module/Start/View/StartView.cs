using Framework.framework.ui.view.impl;
using UnityEngine.UI;

namespace Module.Start.View
{
    public class StartView : UGameView
    {
        public Button Button;
        protected override void OnEnable()
        {
            base.OnEnable();
            Dispatcher.Dispatch("OnEnable");
        }
    }
}