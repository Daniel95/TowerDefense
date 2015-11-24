using UnityEngine;

public class AOE : WaitForCheck {

    private Waypoint waypoint;

    [SerializeField]
    private float heal;

    [SerializeField]
    private float speedMultiply;

    protected override void Awake()
    {
        base.Awake();
        waypoint = GetComponent<Waypoint>();
    }

    protected override void CheckForTarget()
    {
        base.CheckForTarget();

        float randomBuff = Random.Range(0, 0.99f);
        foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, range, checkLayer))
        {
            if (randomBuff < 0.5f) target.GetComponent<Health>().RestoreHealth(heal);
            else target.GetComponent<Waypoint>().SetMoveSpeed = speedMultiply;
        }


        print("HOWL");

        int dir = (int)waypoint.GetRotation;
        if (dir == 1) anim.Play("HowlUpView");
        else if (dir == 2) anim.Play("HowlSideView");
        else if (dir == 3) anim.Play("HowlDownView");
    }
}
