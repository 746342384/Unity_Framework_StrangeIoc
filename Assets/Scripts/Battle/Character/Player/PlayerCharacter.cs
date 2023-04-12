using Battle.Character.Base;
using Battle.Character.Base.Component;
using Battle.Character.Player.State;
using UnityEngine;

namespace Battle.Character.Player
{
    [RequireComponent(typeof(InputComponent))]
    [RequireComponent(typeof(StateMachineComponent))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(MoveComponent))]
    public class PlayerCharacter : CharacterBase
    {
        protected override void OnStart()
        {
            base.OnStart();
            StateMachine.SwitchState(new PlayerIdleState(this));
        }
    }
}