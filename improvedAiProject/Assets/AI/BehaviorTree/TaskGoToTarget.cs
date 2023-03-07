using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private string _targetType;

    public TaskGoToTarget(Transform transform, string targetType)
    {
        _transform = transform;
        _targetType = targetType;

    }

    public override NodeState Evaluate() {
        Transform target = _targetType.Equals("target") ? (Transform)GetData("target") : (Transform)GetData("resource");

        if (Vector3.Distance(_transform.position, target.position) > 0.5f) {
            Vector3 destination = new Vector3(target.position.x, 0, target.position.z);
            
            _transform.position = Vector3.MoveTowards(
                _transform.position, destination, GuardBT.speed * Time.deltaTime);
            _transform.LookAt(target.position);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
