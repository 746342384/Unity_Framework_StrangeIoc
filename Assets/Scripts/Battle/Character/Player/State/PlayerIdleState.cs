using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerIdleState : PlayerStateBase
    {
        public PlayerIdleState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.Play("Idle");
        }

        public override void Tick(float deltaTime)
        {
            Move(Vector3.zero, deltaTime);
        }

        public override void Exit()
        {
        }
    }
}