using UnityEngine;
using UnityEngine.AI;
namespace UniBT.Examples.Scripts.Behavior
{
    public class MoveToTag : Action
    {
        private Transform targetTransform;

        private Companion_Controller companionCC;

        private NavMeshAgent navMesh;

        public override void Start()
        {
            companionCC = gameObject.GetComponent<Companion_Controller>();
            navMesh = gameObject.GetComponent<NavMeshAgent>();
        }

        protected override Status OnUpdate()
        {
            targetTransform = companionCC.target.transform;
            navMesh.destination = targetTransform.position;

            if (Vector3.Distance(navMesh.transform.position, targetTransform.position) < 5f)
                return Status.Success;

            return Status.Running;

        }

        public override void Abort()
        {
            base.Abort();
        }
    }
}