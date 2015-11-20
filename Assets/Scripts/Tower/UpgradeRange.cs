using UnityEngine;

public class UpgradeRange : ParentUpgrade {
    
    [SerializeField]
    private float rangeIncrement;

    private TowerShoot tower;

    void Awake()
    {
        tower = GetComponentInParent<TowerShoot>();
    }

    public override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.UpgradeRange(rangeIncrement);
        print("upgrade");
    }
}
