using UnityEngine;

public class AOEBuff : AOE {

    private FollowWayPoints waypoint;

    [SerializeField]
    private float heal;

    [SerializeField]
    private float speedMultiply;

    protected override void Awake()
    {
        base.Awake();
        waypoint = GetComponent<FollowWayPoints>();
    }

    protected override void CheckForTarget()
    {
        base.CheckForTarget();

        int dir = (int)waypoint.GetRotation;
        if (dir == 1) anim.Play("HowlUpView");
        else if (dir == 2) anim.Play("HowlSideView");
        else if (dir == 3) anim.Play("HowlDownView");
    }

    protected override void Effect(Collider2D target)
    {
        base.Effect(target);
        FollowWayPoints movement = target.GetComponent<FollowWayPoints>();
        if (!movement.GetRandomSpeed)
        {
            target.GetComponent<Health>().RestoreHealth(heal);
            movement.SetMoveSpeedMultiply = speedMultiply;
        }
    }
}
