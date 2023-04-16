using Battle.Character.Base;

namespace Battle.Enemy.State
{
    public class EnemyDeadState : EnemyStateBase
    {
        private readonly CharacterBase _characterBase;

        public EnemyDeadState(CharacterBase characterBase) : base(characterBase)
        {
            _characterBase = characterBase;
        }

        public override void Enter()
        {
            _characterBase.Animator.CrossFadeInFixedTime("Dead", 0.2f);
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void Exit()
        {
        }
    }
}