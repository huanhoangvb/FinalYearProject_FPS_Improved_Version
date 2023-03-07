using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("Take Resource")]
[Help("try to detect Resource")]
public class TakeResource : BasePrimitiveAction
{
    private float detectionRadius = 15.0f;
    [InParam("resource gameobject")]
    [Help("resource gameobject")]
    public GameObject resource;

    [InParam("companion gameobject")]
    [Help("companion gameobject")]
    public Transform companion;

    private UnityEngine.AI.NavMeshAgent navAgent;
    
    public override void OnStart()
    {
        navAgent = companion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        companion.GetComponent<Animator>().SetBool("Attacking",false);
        companion.GetComponent<Animator>().SetBool("Walking", true);
    }

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        if (resource != null)
        {
            Vector3 resPos = resource.transform.position;
            if (resource.TryGetComponent<resource>(out resource res)) {
                navAgent.SetDestination(resPos);
                if (Vector3.Distance(resPos, companion.position) < 1f)
                {
                    res.destroyResource();
                    companion.GetComponent<Companion_Inventory>().addResource("resource", 30);
                }
            }
            return TaskStatus.RUNNING;
        }
        return TaskStatus.COMPLETED;
    } // OnUpdate

}


