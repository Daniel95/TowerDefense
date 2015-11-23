using UnityEngine;

public class UpgradeRange : ParentUpgrade {
    
    [SerializeField]
    private float rangeIncrement;

    private ShootProjectile shooter;

    protected override void Awake()
    {
        base.Awake();
        shooter = GetComponentInParent<ShootProjectile>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        shooter.UpgradeRange(rangeIncrement);
    }
}
