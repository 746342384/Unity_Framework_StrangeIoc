using Battle.Character.Base;

namespace Battle.Enemy.State
{
    public class EnemyIdleState : EnemyStateBase
    {
        private readonly CharacterBase _characterBase;

        public EnemyIdleState(CharacterBase characterBase) : base(characterBase)
        {
            _characterBase = characterBase;
        }

        public override void Enter()
        {
            _characterBase.Animator.CrossFadeInFixedTime("Idle", 0.2f);
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void Exit()
        {
        }
    }
}