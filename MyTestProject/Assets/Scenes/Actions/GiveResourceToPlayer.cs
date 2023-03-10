using UnityEngine;
using UnityEngine.AI;

namespace UniBT.Examples.Scripts.Behavior
{
    public class GiveResourceToPlayer : Action
    {
        private NavMeshAgent navMesh;
        private GameObject gun;

        [SerializeField]
        private GameObject player;

        public override void Awake()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            gameObject.GetComponent<Animator>().SetBool("Attacking", false);
            gameObject.GetComponent<Animator>().SetBool("Walking", true);
        }

        protected override Status OnUpdate()
        {
            gun = GameObject.FindGameObjectsWithTag("Weapon")[0];
            navMesh.SetDestination(player.transform.position);

            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 5f)
            {
                int amount = gameObject.GetComponent<Companion_Inventory>().depleteResource();
                gameObject.GetComponent<Companion_Controller>().resource = false;
                gun.GetComponent<GunScript>().bulletsIHave += amount;
                return Status.Success;
            }

            return Status.Running;
        }


        public override void Abort()
        {
            navMesh.isStopped = true;
        }
    }
}

