using UnityEngine;
using UnityEngine.AI;

namespace UniBT.Examples.Scripts.Behavior
{
    public class GatherResource : Action
    {
        private NavMeshAgent navMesh;

        private Companion_Controller companionCC;

        private GameObject resource;

        public override void Awake()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            companionCC = gameObject.GetComponent<Companion_Controller>();
            gameObject.GetComponent<Animator>().SetBool("Attacking", false);
            gameObject.GetComponent<Animator>().SetBool("Walking", true);
        }

        protected override Status OnUpdate()
        {
            resource = companionCC.target;
            if (resource != null)
            {
                Vector3 resPos = resource.transform.position;
                if (resource.TryGetComponent<resource>(out resource res))
                {
                    navMesh.SetDestination(resPos);
                    if (Vector3.Distance(resPos, gameObject.transform.position) < 1f)
                    {
                        res.destroyResource();
                        gameObject.GetComponent<Companion_Inventory>().addResource(30);
                        companionCC.resource = true;
                    }
                }
                return Status.Running;
            }
            return Status.Success;
        }


        public override void Abort()
        {
            navMesh.isStopped = true;
        }
    }
}