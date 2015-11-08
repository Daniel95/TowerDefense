using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    private int startHealth;

    private int health;

    private Transform healthbar;

    private SpriteRenderer healthbarSprite;

    // Use this for initialization
    void Awake()
    {
        health = startHealth;
        healthbar = transform.Find("Healthbar");
        healthbarSprite = healthbar.GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int dmg) {
        health -= dmg;

        healthbar.localScale = new Vector3((float)health / (float)startHealth, 1, 1);

        if (health <= 0) Destroy(this.gameObject);
        else if (health < startHealth / 3) healthbarSprite.color = Color.red;
        else if (health < startHealth / 1.5f) healthbarSprite.color = Color.yellow;
    }


}
