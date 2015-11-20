using UnityEngine;

public class UpgradeDamage : ParentUpgrade {
    
    [SerializeField]
    private int damageIncrement;

    private TowerShoot tower;

    void Awake()
    {
        tower = GetComponentInParent<TowerShoot>();
    }

    public override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.SetDamage = damageIncrement;
    }
}
