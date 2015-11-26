using UnityEngine;
using System.Collections;

public class AOE : WaitForCheck {

    protected override void CheckForTarget()
    {
        base.CheckForTarget();

        float randomBuff = Random.Range(0, 0.99f);
        foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, range, checkLayer))
        {
            DoSomething(target);
        }
    }

    virtual protected void DoSomething(Collider2D target)
    {

    }
}
