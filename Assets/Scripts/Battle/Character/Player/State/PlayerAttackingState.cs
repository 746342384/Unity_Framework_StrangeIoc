using Battle.Character.Base;

namespace Battle.Character.Player.State
{
    public class PlayerAttackingState : PlayerStateBase
    {
        public PlayerAttackingState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime("MeleeAttack_OneHanded", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var normalizedTime = GetNormalizedTime(Character.Animator);

            if (normalizedTime > 0.5f && Character.InputComponent.CancelAttacking)
            {
                Character.StateMachine.SwitchState(new PlayerJumpState(Character));
                return;
            }

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