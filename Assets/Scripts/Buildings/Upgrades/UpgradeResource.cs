using UnityEngine;

public class UpgradeResource : ParentUpgrade
{
    private RBState resourceBuilding;

    protected override void Awake()
    {
        base.Awake();
        resourceBuilding = GetComponentInParent<RBState>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        resourceBuilding.UpgradeRB();
    }

    public override void SetPointsText()
    {
        base.SetPointsText();
    }

    public int SetPointSpendOnThis {
        set { pointsSpendOnThis = value; }
    }
}
