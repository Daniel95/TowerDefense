using UnityEngine;

public class TargetClosest : WaitForCheck {

    private float shortestDist;

    Vector3 TargetPos;

    protected override void CheckForTarget()
    {
        base.CheckForTarget();
        bool aTargetFound = false;
        shortestDist = range;
        foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, range, checkLayer))
        //foreach (Collider target in Physics.OverlapSphere(transform.position, range, checkLayer))
        {
            float distanceToEnemy = Vector3.Distance(target.gameObject.transform.position, transform.position);
            if (distanceToEnemy < shortestDist)
            {
                shortestDist = distanceToEnemy;
                TargetPos = target.transform.position;
                aTargetFound = true;
            }

        }
        if(aTargetFound) Fire();
    }

    private void Fire()
    {
        if (TargetPos.y > transform.position.y)
        {
            anim.SetBool("FaceToFront", false);
            anim.Play("AttackB");
        }
        else {
            anim.SetBool("FaceToFront", true);
            anim.Play("AttackF");
        }

        if (TargetPos.x < transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
            foreach (Transform child in transform) {
                if (child.name != "Range")
                {
                    child.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
        else {
            transform.localScale = new Vector3(1, 1, 1);
            foreach (Transform child in transform) {
                if (child.name != "Range")
                {
                    child.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        Shoot(TargetPos);
    }

    protected virtual void Shoot(Vector3 targetPos)
    {

    }
}
