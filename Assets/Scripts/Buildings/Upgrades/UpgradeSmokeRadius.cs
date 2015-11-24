using UnityEngine;

public class UpgradeSmokeRadius : ParentUpgrade {
    
    [SerializeField]
    private float radiusIncrement;

    private WaitForCheck tower;

    protected override void Awake()
    {
        base.Awake();
        tower = GetComponentInParent<WaitForCheck>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.SetCooldown = radiusIncrement;
    }
}
