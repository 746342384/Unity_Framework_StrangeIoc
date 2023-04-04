using Battle.Character.Base;
using Battle.Character.Player.State;

namespace Battle.Character.Player
{
    public class PlayerCharacter : CharacterBase
    {
        protected override void OnStart()
        {
            base.OnStart();
            StateMachine.SwitchState(new PlayerIdleState(this));
        }
    }
}