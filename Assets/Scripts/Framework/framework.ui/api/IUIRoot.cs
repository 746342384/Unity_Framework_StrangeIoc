using UnityEngine;

namespace framework.framework.ui.api
{
    public interface IUIRoot
    {
        Transform Root { get; set; }
        Transform NormalRoot { get; set; }
        Transform TopRoot { get; set; }
        Transform PopUpRoot { get; set; }
        Camera UICamera { get; set; }
        Canvas UICanvas { get; set; }
        void Init();

    }
}