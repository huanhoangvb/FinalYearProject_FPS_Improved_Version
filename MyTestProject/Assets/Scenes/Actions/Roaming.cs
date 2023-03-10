using UnityEngine;
using UnityEngine.AI;

namespace UniBT.Examples.Scripts.Behavior
{
    public class Roaming : Action
    {
        private NavMeshAgent navMesh;

        private float distance = 20f;

        public override void Awake()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            gameObject.GetComponent<Animator>().SetBool("Walking", true);
        }

        protected override Status OnUpdate()
        {

            if (!navMesh.pathPending && navMesh.remainingDistance <= navMesh.stoppingDistance)
            {
                navMesh.SetDestination(getRandomPosition());
                return Status.Success;
            }

            return Status.Running;
        }

        private Vector3 getRandomPosition()
        {
            Vector3 pos = gameObject.transform.position;
            float randPosX = UnityEngine.Random.Range(pos.x - distance, pos.x + distance);
            float randPosZ = UnityEngine.Random.Range(pos.z - distance, pos.z + distance);
            return new Vector3(randPosX, pos.y, randPosZ);
        }

        public override void Abort()
        {
            navMesh.isStopped = true;
        }
    }
}