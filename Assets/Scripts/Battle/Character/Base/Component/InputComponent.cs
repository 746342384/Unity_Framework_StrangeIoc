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
        }
    }
}