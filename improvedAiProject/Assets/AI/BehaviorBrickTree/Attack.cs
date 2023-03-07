using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("Attack")]
[Help("attack detected Enemy")]
public class Attack : BasePrimitiveAction
{
    ///<value>Input Target Parameter to to check the distance.</value>
    [InParam("Enemy")]
    [Help("Enemy to hit")]
    public GameObject Enemy;

    [InParam("companion gameobject")]
    [Help("companion gameobject")]
    public Transform companion;

    ///<value>Input Amount of time to wait (in seconds) Parameter.</value>
    [InParam("seconds", DefaultValue = 0.5f)]
    [Help("Amount of time to wait (in seconds) for an attack")]
    public float seconds;

    private float elapsedTime;


    private UnityEngine.AI.NavMeshAgent navAgent;

    public override void OnStart()
    {
        navAgent = companion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgent.isStopped = false;
        companion.GetComponent<Animator>().SetBool("Walking", false);
    }

    // Main class method, invoked by the execution engine.
    public override TaskStatus OnUpdate()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= seconds)
        {
            attack();
            return TaskStatus.COMPLETED;
        }

        return TaskStatus.RUNNING;
    } // OnUpdate

    private void attack() {
        if (Enemy != null)
        {
            if (Enemy.TryGetComponent<EnemyHealthSystem>(out EnemyHealthSystem enemyHealth))
            {
                Vector3 enemyPos = Enemy.transform.position;
                navAgent.destination = enemyPos;
                if (Vector3.Distance(enemyPos, companion.position) < 5f)
                {
                    companion.GetComponent<Animator>().SetBool("Attacking", true);
                    enemyHealth.takeDamage(10);
                }
            }
        }
    }

} // class ShootOnce