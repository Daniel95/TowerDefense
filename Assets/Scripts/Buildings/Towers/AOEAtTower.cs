using UnityEngine;
using System.Collections;

public class AOEAtTower : AOE
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float speedMultiply;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void CheckForTarget()
    {
        base.CheckForTarget();
    }

    protected override void DoSomething(Collider2D target)
    {
        base.DoSomething(target);
        target.GetComponent<Health>().TakeDamage(damage);
        target.GetComponent<FollowWayPoints>().SetMoveSpeed = speedMultiply;
    }
}