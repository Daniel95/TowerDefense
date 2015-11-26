using UnityEngine;

public class UpgradeSmokeSlow : ParentUpgrade {

    [SerializeField]
    private float speedDividerIncrement;

    private ShootSmokeBomb tower;

    protected override void Awake()
    {
        base.Awake();
        tower = GetComponentInParent<ShootSmokeBomb>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.UpgradeSpeedDivider(speedDividerIncrement);
    }
}
