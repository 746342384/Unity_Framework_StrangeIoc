using Battle.Character.Base;
using Battle.Character.Base.Component;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public abstract class PlayerStateBase : StateBase
    {
        protected readonly CharacterBase Character;

        public PlayerStateBase(CharacterBase character)
        {
            Character = character;
        }

        protected void Move(Vector3 motion, float deltaTime)
        {
            var moveMent = Character.MoveMent;
            Character.CharacterController.Move((motion + moveMent) * deltaTime);
        }
    }
}