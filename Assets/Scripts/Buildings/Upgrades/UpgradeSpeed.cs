using UnityEngine;

public class UpgradeSpeed : ParentUpgrade {
    
    [SerializeField]
    private float cooldownDivider;

    private WaitForCheck tower;

    void Start()
    {
        if (cooldownDivider > 1) print("ERROR DIVIDEND HIGHER THEN 1 NOT SUPPORTED"); 
        tower = GetComponentInParent<WaitForCheck>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.upgradeSpeed(cooldownDivider);
    }
}
