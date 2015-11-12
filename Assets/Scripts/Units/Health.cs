using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    private float startHealth;

    private float health;

    private float startScale;

    private Transform healthbar;

    private SpriteRenderer healthbarSprite;

    // Use this for initialization
    void Awake()
    {
        healthbar = transform.Find("Healthbar");
        healthbarSprite = healthbar.GetComponent<SpriteRenderer>();
        health = startHealth;
        startScale = healthbar.localScale.x;
        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
    }

    public void TakeDamage(int dmg) {
        health -= dmg;

        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);

        if (health <= 0) Destroy(gameObject);
        else if (health < startHealth / 3) healthbarSprite.color = Color.red;
        else if (health < startHealth / 1.5f) healthbarSprite.color = Color.yellow;
    }
}
