using UnityEngine;

namespace Battle.Character.Base.Component
{
    public abstract class StateBase
    {
        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
        
        protected float GetNormalizedTime(Animator animator)
        {
            var currentInfo = animator.GetCurrentAnimatorStateInfo(0);
            return currentInfo.normalizedTime;
        }
    }
}