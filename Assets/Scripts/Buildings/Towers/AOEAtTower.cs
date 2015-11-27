using UnityEngine;
using System.Collections;

public class AOEAtTower : AOE
{
    [SerializeField]
    private float startDamage;

    [SerializeField]
    private float startSpeedDivider;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void CheckForTarget()
    {
        base.CheckForTarget();
    }

    protected override void Effect(Collider2D target)
    {
        base.Effect(target);
        target.GetComponent<Health>().TakeDamage(startDamage);
        target.GetComponent<FollowWayPoints>().DivideSpeed(startSpeedDivider);
    }

    public void UpgradeSpeedDivider(float _upgrade) {
        startSpeedDivider += _upgrade;
    }

    public void UpgradeDamage(float _upgrade)
    {
        startDamage += _upgrade;
    }
}