using UnityEngine;
using System.Collections;

public class DamageBuilding : MonoBehaviour {

    [SerializeField]
    private int damage;

    void OnCollisionEnter2D(Collision2D other) {
        Resources building = other.gameObject.GetComponent<Resources>();
        if (building != null) {
            Health health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            if (building.checkTreeHouse) Destroy(this.gameObject);
        }
    }
}
