namespace Battle.Character.Player.State
{
    public class PlayerGetHitState : PlayerStateBase
    {
        public PlayerGetHitState(PlayerBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime(Character.CharacterData.GetHitAnimationName, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var n = GetNormalizedTime(Character.Animator);
            if (n >= 1f)
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