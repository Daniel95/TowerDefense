using UnityEngine;

public class UpgradeAOEDamage : ParentUpgrade
{

    [SerializeField]
    private float damageIncrement;

    private AOEAtTower shooter;

    protected override void Awake()
    {
        base.Awake();
        shooter = GetComponentInParent<AOEAtTower>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        //shooter.SetUpgradeDamage = damageIncrement;
        shooter.UpgradeDamage(damageIncrement);
    }
}