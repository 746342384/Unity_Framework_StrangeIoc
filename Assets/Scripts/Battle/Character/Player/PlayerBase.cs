using Battle.Character.Base;
using Battle.Character.Base.Component;
using Battle.Character.Controller;
using Battle.Character.Player.State;
using Cinemachine;
using UnityEngine;

namespace Battle.Character.Player
{
    [RequireComponent(typeof(InputComponent))]
    [RequireComponent(typeof(MoveComponent))]
    public class PlayerBase : CharacterBase
    {
        private CinemachineStateDrivenCamera CinemachineStateDriven { get; set; }
        public InputComponent InputComponent { get; private set; }
        public MoveComponent MoveComponent { get; private set; }
        public Transform MainCameraTransform { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();

            InputComponent = GetComponent<InputComponent>();
            MoveComponent = GetComponent<MoveComponent>();
            CinemachineStateDriven = TransformDeepFind.FindDeepComponent<CinemachineStateDrivenCamera>(transform);
        }

        protected override void OnInit()
        {
            base.OnInit();

            MainCameraTransform = BattleController.Ins.Camera.transform;
            MoveComponent.Init(this);
            StateMachine.SwitchState(new PlayerMoveState(this));
            CharacterType = CharacterType.Player;
            CinemachineStateDriven.m_AnimatedTarget = Animator;
        }

        protected override void OnSingleTakeDamage(CharacterBase origin, int attackDataIndex, Vector3 raycastHitPoint)
        {
            base.OnSingleTakeDamage(origin, attackDataIndex, raycastHitPoint);
            if (!IsDead)
            {
                StateMachine.SwitchState(new PlayerGetHitState(this));
            }
        }

        protected override void OnDead()
        {
            base.OnDead();
            StateMachine.SwitchState(new PlayerDeadState(this));
        }

        protected override void OnReborn()
        {
            base.OnReborn();
            StateMachine.SwitchState(new PlayerMoveState(this));
        }
    }
}