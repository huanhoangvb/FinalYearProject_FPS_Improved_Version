using System.Collections.Generic;
using BehaviorTree;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoints;
    public UnityEngine.GameObject arrowPrefab;

    public static float speed = 2f;
    public static float fovRange = 6f;


    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>{
                new CheckEnemyInFOVRange(transform),
            }),
            //new TaskPatrol(transform,waypoints),
            new TaskRandomPatrol(transform),
            new Sequence(new List<Node>{
                new CheckResourceInFOVRange(transform, arrowPrefab),
                new TaskGoToTarget(transform,"resource")
            })
            
            
        });
            

        return root;
    }

}