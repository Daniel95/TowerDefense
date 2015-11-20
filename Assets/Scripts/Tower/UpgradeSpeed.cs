using UnityEngine;

public class UpgradeSpeed : ParentUpgrade {
    
    [SerializeField]
    private float speedIncrement;

    private TowerShoot tower;

    void Awake()
    {
        tower = GetComponentInParent<TowerShoot>();
        //upgrades = transform.parent.GetComponent<Upgrades>();
    }

    public override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.SetCooldown = speedIncrement;
    }
}
