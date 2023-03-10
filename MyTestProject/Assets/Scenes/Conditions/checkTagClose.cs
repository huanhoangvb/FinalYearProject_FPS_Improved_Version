using UnityEngine;
using UnityEngine.AI;

namespace UniBT.Examples.Scripts.Behavior
{
    public class checkTagClose : Conditional
    {
        [SerializeField]
        private string tag;

        [SerializeField]
        private Transform companionTransform;

        private float detectionRadius = 15.0f;

        protected override bool IsUpdatable()
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            gameObject.GetComponent<Animator>().SetBool("Walking", true);
            Vector3 center = companionTransform.position;
            int maxColliders = 10;
            Collider[] hitColliders = new Collider[maxColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(center, detectionRadius, hitColliders);
            if (numColliders > 0)
            {
                for (int i = 0; i < numColliders; i++)
                {
                    if (hitColliders[i].CompareTag(tag))
                    {
                        companionTransform.GetComponent<Companion_Controller>().target = hitColliders[i].gameObject;
                        return true;
                    }
                }
            }

            return false;
        }


        public override void Abort()
        {

        }
    }
}