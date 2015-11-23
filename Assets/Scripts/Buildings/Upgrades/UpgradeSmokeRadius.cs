using UnityEngine;

public class UpgradeSmokeRadius : ParentUpgrade {
    
    [SerializeField]
    private float radiusIncrement;

    private DetectTarget tower;

    protected override void Awake()
    {
        base.Awake();
        tower = GetComponentInParent<DetectTarget>();
    }

    protected override void UpgradeTower()
    {
        base.UpgradeTower();
        tower.SetCooldown = radiusIncrement;
    }
}
