using Battle.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Battle.Character.Base.Component
{
    public class AIMoveComponent : MonoBehaviour
    {
        private CharacterBase CharacterBase;
        private NavMeshAgent Agent;
        private CharacterType CharacterType;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        public void Init(CharacterBase characterBase)
        {
            CharacterBase = characterBase;
            CharacterType = characterBase.CharacterType;
        }

        public void MoveToTarget(float deltaTime)
        {
            var targetPos = Vector3.zero;
            switch (CharacterType)
            {
                case CharacterType.Player:
                    break;
                case CharacterType.Enemy:
                    targetPos = ((EnemyBase)CharacterBase).Target.transform.position;
                    break;
            }

            if (Agent.isOnNavMesh)
            {
                Agent.destination = targetPos;
                Move(Agent.desiredVelocity.normalized * CharacterBase.CharacterData.MoveSpeed, deltaTime);
            }

            Agent.velocity = CharacterBase.CharacterController.velocity;
        }

        public void Move(Vector3 motion, float deltaTime)
        {
            CharacterBase.CharacterController.Move((motion) * deltaTime);
        }
    }
}