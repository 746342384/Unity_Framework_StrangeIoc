using UnityEngine;

namespace Battle.Character.Base.Component
{
    public class StateMachineComponent : MonoBehaviour
    {
        public StateBase CurrentState { get; set; }

        public void Update()
        {
            CurrentState?.Tick(Time.deltaTime);
        }

        public void SwitchState(StateBase stateBase)
        {
            CurrentState?.Exit();
            CurrentState = stateBase;
            CurrentState?.Enter();
        }
    }
}