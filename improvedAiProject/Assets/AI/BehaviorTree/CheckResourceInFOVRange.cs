using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckResourceInFOVRange : Node
{
    private static int _resourceLayerMask = 1 << 7;
    private Transform _transform;
    private Animator _animator;
    private GameObject _arrowPrefab;

    public CheckResourceInFOVRange(Transform transform, GameObject arrowPrefab) {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _arrowPrefab = arrowPrefab;
    }

    public override NodeState Evaluate() {
        object t = GetData("resource");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, GuardBT.fovRange * 2, _resourceLayerMask);
            if (colliders.Length > 0)
            {
                parent.parent.SetData("resource", colliders[0].transform);
                _animator.SetBool("Walking", true);

                Object.Instantiate(_arrowPrefab, colliders[0].transform.position, new Quaternion(0f,180f,0f,0f));

                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
