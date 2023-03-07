using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("DetectWithTag")]
[Help("try to detect GameObject with given tag")]
public class DetectingTag : BasePrimitiveAction
{
    ///<value>Input Target Parameter to to check the distance.</value>
    [InParam("tag")]
    [Help("tag")]
    public string tag;

    [InParam("sourceGameObject")]
    [Help("From which the Sphere start from")]
    public Transform transform;

    private float detectionRadius = 15.0f;
    [OutParam("GameObject Detected")]
    [Help("Return value of GameObject that detected by given tag")]
    public GameObject detectedGameObject;

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
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
                    detectedGameObject = hitColliders[i].gameObject;

                    break;
                }
            }
        }
        return TaskStatus.COMPLETED;

    } // OnUpdate

} // class ShootOnce
