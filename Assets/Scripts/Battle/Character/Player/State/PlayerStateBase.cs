using Battle.Character.Base;
using Battle.Character.Base.Component;

namespace Battle.Character.Player.State
{
    public abstract class PlayerStateBase : StateBase
    {
        protected readonly CharacterBase Character;
        protected bool IsApplyForce;
        protected float AddForce;

        protected PlayerStateBase(CharacterBase character)
        {
            Character = character;
        }
    }
}