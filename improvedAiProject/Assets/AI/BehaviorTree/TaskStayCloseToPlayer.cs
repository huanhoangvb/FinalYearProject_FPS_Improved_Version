using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskStayCloseToPlayer : Node
{
    private Transform _transform;
    private GameObject _player;

    public TaskStayCloseToPlayer(Transform transform, GameObject player) {
        _player = player;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        if (Vector3.Distance(_transform.position, _player.transform.position) > 0.5f)
        {
            _transform.position = Vector3.MoveTowards(
                            _transform.position,
                            _player.transform.position,
                            GuardBT.speed * Time.deltaTime);
            _transform.LookAt(_player.transform.position);
        }
        state = NodeState.RUNNING;
        return state;
    }
}
