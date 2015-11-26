using UnityEngine;
using System.Collections;

public class AOE : WaitForCheck {

    protected override void CheckForTarget()
    {
        base.CheckForTarget();

        foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, range, checkLayer))
        {
            Effect(target);
        }
    }

    virtual protected void Effect(Collider2D target)
    {

    }
}
