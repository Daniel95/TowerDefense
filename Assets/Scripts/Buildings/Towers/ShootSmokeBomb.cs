using UnityEngine;

public class ShootSmokeBomb : ShootProjectile
{

    private float speedDividend;

    private float radius;

    protected override void FireProjectile(Vector3 targetPos)
    {
        base.FireProjectile(targetPos);
        Explode explosion = projectile.GetComponent<Explode>();
        //explosion.SetSmokeUpgrades = upgradeSmoke;
        explosion.SetSmokeDamage = damage;
        explosion.SetSmokeRadius = radius;
        explosion.SetSpeedDividend = speedDividend;
    }

    public float setSpeedDividend
    {
        set { speedDividend = value; }
    }

    public float setRadius
    {
        set { radius = value; }
    }
}