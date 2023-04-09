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
            var layer = 0;
            var currentInfo = animator.GetCurrentAnimatorStateInfo(layer);
            var nextInfo = animator.GetNextAnimatorStateInfo(layer);
            if (animator.IsInTransition(layer))
            {
                return nextInfo.normalizedTime % 1f;
            }

            if (Mathf.Abs(1.0f - currentInfo.normalizedTime) <= threshold)
            {
                return 1f;
            }

            return currentInfo.normalizedTime % 1f;
        }

        private const float threshold = 0.05f;
    }
}