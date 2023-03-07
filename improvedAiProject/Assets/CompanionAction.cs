using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionAction : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private NavMeshAgent companionNavMesh;
    private Companion_Inventory inventory;
    private float _attackTime = 0.2f;
    private float _attackCounter = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
        companionNavMesh = GetComponent<NavMeshAgent>();
        inventory = GetComponent<Companion_Inventory>();
    }

    public void Attack(Transform enemy)
    {
        Debug.Log("Attack");
        enemy.GetComponent<EnemyHealthSystem>().takeDamage(10);
        _attackCounter = 0f;
        _animator.SetBool("Attacking", true);
    }
    public void TakeResource(Transform resource)
    {
        Debug.Log("resource!!");
        companionNavMesh.SetDestination(resource.position);
        inventory.addResource(resource.gameObject.name,1);
        resource.GetComponent<resource>().destroyResource();
    }
}
