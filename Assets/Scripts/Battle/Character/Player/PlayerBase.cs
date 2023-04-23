using Battle.Character.Base;
using Battle.Character.Base.Component;
using Battle.Character.Player.State;
using UnityEngine;

namespace Battle.Character.Player
{
    [RequireComponent(typeof(InputComponent))]
    [RequireComponent(typeof(MoveComponent))]
    public class PlayerBase : CharacterBase
    {
        public InputComponent InputComponent { get; private set; }
        public MoveComponent MoveComponent { get; private set; }
        public Transform MainCameraTransform;

        protected override void OnAwake()
        {
            base.OnAwake();
            InputComponent = GetComponent<InputComponent>();
            MoveComponent = GetComponent<MoveComponent>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MoveComponent.Init(this);
            StateMachine.SwitchState(new PlayerMoveState( this));
            CharacterType = CharacterType.Player;
        }
        
        protected override void OnSingleTakeDamage(CharacterBase origin, int attackDataIndex, Vector3 raycastHitPoint)
        {
            base.OnSingleTakeDamage(origin, attackDataIndex, raycastHitPoint);
            if (!IsDead)
            {
                StateMachine.SwitchState(new PlayerGetHitState(this));
            }
        }
    }
}