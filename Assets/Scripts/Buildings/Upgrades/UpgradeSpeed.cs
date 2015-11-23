using UnityEngine;

public class UpgradeSpeed : ParentUpgrade {
    
    [SerializeField]
    private float cooldownDividend;

    private DetectTarget tower;

    void Start()
    {
        if (cooldownDividend > 1) print("ERROR DIVIDEND HIGHER THEN 1 NOT SUPPORTED"); 
        tower = GetComponentInParent<DetectTarget>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.SetCooldown = cooldownDividend;
    }
}
