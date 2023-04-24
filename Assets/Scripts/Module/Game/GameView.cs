using Framework.framework.ui.view.impl;
using UnityEngine.UI;

namespace Module.Game
{
    public class GameView : UGameView
    {
        public Button RebornBtn { get; set; }
        public Button CreateEnemyBtn { get; set; }
        public Button CreatePlayerBtn { get; set; }

        protected override void Awake()
        {
            RebornBtn = TransformDeepFind.FindDeepComponent<Button>(transform, nameof(RebornBtn));
            CreateEnemyBtn = TransformDeepFind.FindDeepComponent<Button>(transform, nameof(CreateEnemyBtn));
            CreatePlayerBtn = TransformDeepFind.FindDeepComponent<Button>(transform, nameof(CreatePlayerBtn));
            base.Awake();
        }
    }
}