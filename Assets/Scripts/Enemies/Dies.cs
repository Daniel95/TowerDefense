using UnityEngine;

public class Dies : Health {

    override protected void Awake()
    {
        base.Awake();
        health = startHealth;
        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
    }

    protected override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
    }
}
