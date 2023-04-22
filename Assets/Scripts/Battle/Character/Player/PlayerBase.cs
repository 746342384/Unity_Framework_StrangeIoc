using Battle.Character.Base;
using Battle.Character.Base.Component;
using Battle.Character.Player.State;
using UnityEngine;

namespace Battle.Character.Player
{
    [RequireComponent(typeof(InputComponent))]
    [RequireComponent(typeof(StateMachineComponent))]
    [RequireComponent(typeof(MoveComponent))]
    public class PlayerBase : CharacterBase
    {
        public Transform MainCameraTransform;
        protected override void OnStart()
        {
            base.OnStart();
            StateMachine.SwitchState(new PlayerMoveState( this));
            CharacterType = CharacterType.Player;
        }
    }
}