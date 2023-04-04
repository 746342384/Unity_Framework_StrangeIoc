
namespace Battle.Character.Base.Component
{
    public abstract class StateBase
    {
        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
    }
}