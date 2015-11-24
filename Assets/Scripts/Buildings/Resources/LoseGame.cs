using UnityEngine;
public class LoseGame : Health {

    private HealthText healthText; 

    protected override void Awake()
    {
        healthText = GameObject.Find("Lives Text").GetComponent<HealthText>();

        base.Awake();
        health = startHealth;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        healthText.SetText(health);
    }

    protected override void Die()
    {
        base.Die();
        Application.LoadLevel("Menu");
    }
}
