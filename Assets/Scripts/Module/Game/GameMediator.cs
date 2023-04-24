using Battle.Character.Controller;
using Framework.framework.ui.mediator.impl;

namespace Module.Game
{
    public class GameMediator : UGameMediator<GameView>
    {
        public override void OnRegister()
        {
            base.OnRegister();
            View.RebornBtn.onClick.AddListener(Reborn);
            View.CreatePlayerBtn.onClick.AddListener(CreatePlayer);
            View.CreateEnemyBtn.onClick.AddListener(CreateEnemy);
        }

        private void CreateEnemy()
        {
            const string enemyPath = "Assets/ResPackage/Common/Prefab/Enemy/Enemy.prefab";
            BattleController.Ins.CreateEnemy(enemyPath);
        }

        private void CreatePlayer()
        {
            const string playerPath = "Assets/ResPackage/Common/Prefab/Player/Player.prefab";
            BattleController.Ins.CreatePlayer(playerPath);
        }

        private void Reborn()
        {
            BattleController.Ins.RebornPlayers();
        }
    }
}