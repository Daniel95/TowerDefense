using UnityEngine;

public class UpgradeAOESlow : ParentUpgrade
{

    [SerializeField]
    private float SlowDividerIncrement;

    private AOEAtTower shooter;

    protected override void Awake()
    {
        base.Awake();
        shooter = GetComponentInParent<AOEAtTower>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        shooter.UpgradeSpeedDivider(SlowDividerIncrement);
    }
}