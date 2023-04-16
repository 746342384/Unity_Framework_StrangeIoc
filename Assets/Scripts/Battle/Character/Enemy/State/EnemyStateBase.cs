using Battle.Character.Base;
using Battle.Character.Base.Component;

namespace Battle.Enemy.State
{
    public abstract class EnemyStateBase : StateBase
    {
        protected readonly CharacterBase CharacterBase;

        public EnemyStateBase(CharacterBase characterBase)
        {
            CharacterBase = characterBase;
        }
    }
}