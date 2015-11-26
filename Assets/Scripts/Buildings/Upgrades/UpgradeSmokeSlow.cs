using UnityEngine;

public class UpgradeSmokeSlow : ParentUpgrade {

    [SerializeField]
    private float speedDividendIncrement;

    private ShootSmokeBomb tower;

    protected override void Awake()
    {
        base.Awake();
        tower = GetComponentInParent<ShootSmokeBomb>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.SetUpgradeSpeedDividend = speedDividendIncrement;
    }
}
