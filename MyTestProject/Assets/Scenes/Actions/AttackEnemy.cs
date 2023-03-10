using UnityEngine;
using UnityEngine.AI;

namespace UniBT.Examples.Scripts.Behavior
{
    public class AttackEnemy : Action
    {
        public float seconds;

        private NavMeshAgent navAgent;


        private float elapsedTime = 0;

        private Companion_Controller companionCC;
        private GameObject Enemy;

        public override void Awake()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            navAgent.isStopped = false;
            companionCC = gameObject.GetComponent<Companion_Controller>();
            gameObject.GetComponent<Animator>().SetBool("Walking", false);
        }

        protected override Status OnUpdate()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= seconds)
            {
                attack();
                elapsedTime = 0;
                return Status.Success;
            }

            return Status.Running;
        }

        private void attack()
        {
            Enemy = companionCC.target;
            if (Enemy != null)
            {
                if (Enemy.TryGetComponent<EnemyHealthSystem>(out EnemyHealthSystem enemyHealth))
                {
                    Vector3 enemyPos = Enemy.transform.position;
                    navAgent.destination = enemyPos;
                    if (Vector3.Distance(enemyPos, gameObject.transform.position) < 7f)
                    {
                        gameObject.GetComponent<Animator>().SetBool("Walking", false);
                        gameObject.GetComponent<Animator>().SetBool("Attacking", true);
                        enemyHealth.takeDamage(10);
                    }
                }
            }
        }

        public override void Abort()
        {
            elapsedTime = 0.0f;
        }
    }
}