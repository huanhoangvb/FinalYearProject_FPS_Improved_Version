using UnityEngine;
using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Framework; // ConditionBase
namespace BBUnity.Conditions
{
    [Condition("isTagClose?")]
    [Help("Check if target with tag is close")]
    public class IsTagClose : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
        [InParam("target")]
        [Help("target")]
        public string tag;

        [InParam("sourceGameObject")]
        [Help("From which the Sphere start from")]
        public Transform transform;

        private float detectionRadius = 15.0f;
        GameObject target;

        public override bool Check()
        {
            Vector3 center = transform.position;
            int maxColliders = 10;
            Collider[] hitColliders = new Collider[maxColliders];
            int numColliders = Physics.OverlapSphereNonAlloc(center, detectionRadius, hitColliders);
            if (numColliders > 0)
            {
                for (int i = 0; i < numColliders; i++)
                {
                    if (hitColliders[i].CompareTag(tag))
                    {
                        target = hitColliders[i].gameObject;
                        break;
                    }
                }

                if (target != null)
                    return true;
            }

            return false;
        }
    }
}