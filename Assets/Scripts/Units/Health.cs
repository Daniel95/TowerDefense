using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    [SerializeField]
    private int health;

    public void TakeDamage(int dmg) {
        health -= dmg;
        if (dmg < 0) Destroy(this);
    }
}
