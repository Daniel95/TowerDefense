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

    public override void SeeEnemy(GameObject _enemy)
    {
        base.SeeEnemy(_enemy); // voor alles in de parent functie ook uit
        if (cooldownValue < 0) {
            //Debug.Log("seeingenemy");
            DamageEnemy(_enemy);
            cooldownValue = cooldown;
        }
        cooldownValue -= 1 * Time.deltaTime;
    }

    public virtual void DamageEnemy(GameObject _enemy)
    {
        Health enemyHealth =_enemy.GetComponent<Health>();
        enemyHealth.TakeDamage(damage);
    }
}
