using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskRandomPatrol : Node
{
    private Transform _transform;
    private Vector3 wp;
    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;
    private Animator _animator;

    public TaskRandomPatrol(Transform transform) {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        wp = _transform.position;
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                _animator.SetBool("Walking", true);
            }
        }
        else
        {

            if (Vector3.Distance(_transform.position, wp) < 0.01f)
            {
                _transform.position = wp;
                _waitCounter = 0f;
                _waiting = true;

                wp = randomMovingLocation();
                _animator.SetBool("Walking", false);
            }
            else {
                _transform.position = Vector3.MoveTowards(
                        _transform.position,
                        wp,
                        GuardBT.speed * Time.deltaTime);
                _transform.LookAt(wp);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

     private Vector3 randomMovingLocation() {
        float movingRange = GuardBT.fovRange;
        float randomX = Random.Range(-movingRange, movingRange);
        float randomZ = Random.Range(-movingRange, movingRange);

        Vector3 newLocation =  _transform.position + new Vector3(randomX,0,randomZ);

        return newLocation;
    }
}
