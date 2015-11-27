using UnityEngine;

public class UpgradeDamage : ParentUpgrade {
    
    [SerializeField]
    private int damageIncrement;

    private ShootProjectile shooter;

    protected override void Awake()
    {
        base.Awake();
        shooter = GetComponentInParent<ShootProjectile>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        shooter.UpgradeDamage(damageIncrement);
    }
}
