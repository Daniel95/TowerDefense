using UnityEngine;
using System.Collections;

public class TowerShoot : TargetObj {

    [SerializeField]
    private int damage;

    [SerializeField]
    private float cooldown;

    private float cooldownValue;

    void Awake() {
        cooldownValue = cooldown;
    }

    public override void DetectEnemy(GameObject _enemy)
    {
        base.DetectEnemy(_enemy); // voor alles in de parent functie ook uit

        Debug.Log("Enemy In Sight");

        if (cooldown < 0) {
            //enemy.TakeDamage(damage);
            cooldownValue = cooldown;
        }
        cooldownValue--;
    }

    public override void LoseEnemy(GameObject _enemy)
    {
        base.DetectEnemy(_enemy); // voor alles in de parent functie ook uit

        Debug.Log("Lost Sight of the enemy");
    }
}
