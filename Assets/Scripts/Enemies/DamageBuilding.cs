using UnityEngine;
using System.Collections;

public class DamageBuilding : MonoBehaviour {

    [SerializeField]
    private int damage;

    void OnCollisionEnter2D(Collision2D other) {
        CollectResources building = other.gameObject.GetComponent<CollectResources>();
        if (building != null) {
            Health health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            if (other.gameObject.GetComponent<LoseGame>()) Destroy(this.gameObject);
        }
    }
}
