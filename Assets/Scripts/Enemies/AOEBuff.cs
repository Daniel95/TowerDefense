using UnityEngine;
using System.Collections;

public class AOEBuff : AOE {

    private FollowWayPoints waypoint;

    [SerializeField]
    private float heal;

    [SerializeField]
    private float speedMultiply;

    private float randomBuff;

    protected override void Awake()
    {
        base.Awake();
        waypoint = GetComponent<FollowWayPoints>();
    }

    protected override void CheckForTarget()
    {
        base.CheckForTarget();

        randomBuff = Random.Range(0, 0.99f);

        int dir = (int)waypoint.GetRotation;
        if (dir == 1) anim.Play("HowlUpView");
        else if (dir == 2) anim.Play("HowlSideView");
        else if (dir == 3) anim.Play("HowlDownView");
    }

    protected override void DoSomething(Collider2D target)
    {
        base.DoSomething(target);
        if (randomBuff < 0.5f) target.GetComponent<Health>().RestoreHealth(heal);
        else target.GetComponent<FollowWayPoints>().SetMoveSpeed = speedMultiply;
    }
}
