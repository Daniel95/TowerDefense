using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    protected float startHealth;

    protected float health;

    protected float startScale;

    protected Transform healthbar;

    private SpriteRenderer healthbarSprite;

    // Use this for initialization
    virtual protected void Awake()
    {
        healthbar = transform.Find("Healthbar");
        healthbarSprite = healthbar.GetComponent<SpriteRenderer>();
        startScale = healthbar.localScale.x;
        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
    }

    public virtual void TakeDamage(float dmg) {
        health -= dmg;
        if (health > 0)
        {
            healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);

            if (health < startHealth / 3) healthbarSprite.color = Color.red;
            else if (health < startHealth / 1.5f) healthbarSprite.color = Color.yellow;
        }
        else
        {
            healthbarSprite.color = Color.green;
            healthbar.localScale = new Vector3(0, 1, 1);
            Die();
        }
    }

    public void RestoreHealth(float heal) {
        if (health < startHealth) health += heal; 
    }

    protected virtual void Die() {

    }
}
