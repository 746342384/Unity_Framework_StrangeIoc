using Battle.Character.Player.State;
using UnityEngine;

namespace Battle.Character.Base.Component
{
    public class InputComponent : MonoBehaviour
    {
        public CharacterBase CharacterBase;
        public float HorizontalInput;
        public float VerticalInput;

        private void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");

            if (HorizontalInput == 0 && VerticalInput == 0)
            {
                CharacterBase.StateMachine.SwitchState(new PlayerIdleState(CharacterBase));
            }
            else
            {
                CharacterBase.StateMachine.SwitchState(new PlayerMoveState(CharacterBase));
            }
        }
    }
}