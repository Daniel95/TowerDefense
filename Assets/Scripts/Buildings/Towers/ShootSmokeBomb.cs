using UnityEngine;

public class ShootSmokeBomb : ShootProjectile
{
    [SerializeField]
    private int divideDamage;

    [SerializeField]
    private float startSpeedDividend;

    private float upgradeSpeedDividend;
    
    [SerializeField]
    private float startRadius;
    
    private float upgradeRadius;

    protected override void FireProjectile(Vector3 targetPos)
    {
        base.FireProjectile(targetPos);
        Explode explosion = projectile.GetComponent<Explode>();
        explosion.SetSmokeDamage = damage / divideDamage;
        explosion.SetSmokeRadius = startRadius + upgradeRadius;
        explosion.SetSpeedDividend = startSpeedDividend + upgradeSpeedDividend;
    }

    public float SetUpgradeSpeedDividend
    {
        set { upgradeSpeedDividend = value; }
    }

    public float setUpgradeRadius
    {
        set { upgradeRadius = value; }
    }
}