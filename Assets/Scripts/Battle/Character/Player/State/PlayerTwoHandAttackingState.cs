using Battle.Character.Base;

namespace Battle.Character.Player.State
{
    public class PlayerTwoHandAttackingState : PlayerStateBase
    {
        public PlayerTwoHandAttackingState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime("MeleeAttack_TwoHanded", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}