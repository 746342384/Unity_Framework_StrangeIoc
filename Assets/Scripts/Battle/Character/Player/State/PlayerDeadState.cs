namespace Battle.Character.Player.State
{
    public class PlayerDeadState : PlayerStateBase
    {
        public PlayerDeadState(PlayerBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime("Dead", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void Exit()
        {
        }
    }
}