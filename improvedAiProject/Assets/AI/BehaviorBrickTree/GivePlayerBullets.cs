using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("Give Bullets to Player")]
[Help("Give Bullets to Player")]
public class GivePlayerBullets : BasePrimitiveAction
{
    ///<value>Input Target Parameter to to check the distance.</value>
    private GameObject gun;

    [InParam("companion gameobject")]
    [Help("companion gameobject")]
    public Transform companion;

    [InParam("player gameobject")]
    [Help("player gameobject")]
    public GameObject player;

    private UnityEngine.AI.NavMeshAgent navAgent;

    public override void OnStart()
    {
        gun = UnityEngine.GameObject.FindGameObjectsWithTag("Weapon")[0];
        navAgent = companion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        companion.GetComponent<Animator>().SetBool("Attacking", false);
        companion.GetComponent<Animator>().SetBool("Walking", true);
    }

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        navAgent.SetDestination(player.transform.position);

        if(Vector3.Distance(companion.position,player.transform.position) < 5f) {
            int amount = companion.GetComponent<Companion_Inventory>().depleteResource();
            gun.GetComponent<GunScript>().bulletsIHave += amount;
            return TaskStatus.COMPLETED;
        }

        return TaskStatus.RUNNING;
    } // OnUpdate

} // class ShootOnce
