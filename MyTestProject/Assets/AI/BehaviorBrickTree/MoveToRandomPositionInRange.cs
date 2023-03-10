using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/MoveToRandomPosition in Range")]
    [Help("using a NavMeshAgent to move to a random position nearby")]
    public class MoveToRandomPositionInRange : BasePrimitiveAction
    {
        private UnityEngine.AI.NavMeshAgent navAgent;

        ///<value>Input game object Parameter that must have a BoxCollider or SphereColider, which will determine the area from which the position is extracted.</value>
        [InParam("companion Transform")]
        [Help("companion transform")]
        public Transform companion;

        private float distance = 20f;

        public override void OnStart()
        {
            navAgent = companion.GetComponent<UnityEngine.AI.NavMeshAgent>();
            navAgent.SetDestination(getRandomPosition());
        }
        /// <summary>Method of Update of MoveToRandomPosition </summary>
        /// <remarks>Check the status of the task, if it has traveled the road or is close to the goal it is completed
        /// and otherwise it will remain in operation.</remarks>
        public override TaskStatus OnUpdate()
        {

            if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                navAgent.SetDestination(getRandomPosition());
                return TaskStatus.COMPLETED;
            }

            return TaskStatus.RUNNING;
        }

        private Vector3 getRandomPosition()
        {
            Vector3 pos = companion.transform.position;
            float randPosX = Random.Range(pos.x - distance, pos.x + distance);
            float randPosZ = Random.Range(pos.z - distance, pos.z + distance);
            return new Vector3(randPosX, pos.y, randPosZ);
        }
        /// <summary>Abort method of MoveToRandomPosition </summary>
        /// <remarks>When the task is aborted, it stops the navAgentMesh.</remarks>
        public override void OnAbort()
        {
#if UNITY_5_6_OR_NEWER
            navAgent.isStopped = true;
#else
                navAgent.Stop();
#endif
        }
    }
}
