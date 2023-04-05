using Battle.Character.Base;

namespace Battle.Character.Player.State
{
    public class PlayerJumpWhileRunning : PlayerStateBase
    {
        public PlayerJumpWhileRunning(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime("JumpWhileRunning", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var vector2 = GetMovement();
            var movement = CalculateMovement(vector2);
            Move(movement * Character.CharacterData.MoveSpeed, deltaTime);
            if (vector2.x != 0)
            {
                FaceMovementDirection(movement, deltaTime);
            }

            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}