using UnityEngine;

public class ShootSmokeBomb : ShootProjectile
{
    [SerializeField]
    private int divideDamage;

    [SerializeField]
    private float startSpeedDivider;
    
    [SerializeField]
    private float startRadius;

    protected override void FireProjectile(Vector3 targetPos)
    {
        base.FireProjectile(targetPos);
        Explode explosion = bullet.GetComponent<Explode>();
        explosion.SetSmokeDamage = (float)damage / (float)divideDamage;
        explosion.SetSmokeRadius = startRadius;
        explosion.SetSpeedDivide = startSpeedDivider;
    }

    public void UpgradeSpeedDivider(float _upgrade)
    {
        startSpeedDivider += _upgrade;
    }

    public void UpgradeRadius(float _upgrade)
    {
        startRadius += _upgrade;
    }
}