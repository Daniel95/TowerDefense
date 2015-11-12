using UnityEngine;
using System.Collections;

public class BulletInfo : MonoBehaviour {

    public float speed;
    public Vector3 targetPos;
    public int damage;

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetPos, speed * Time.deltaTime);
       if (transform.position == targetPos) Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Enemy") {
            Health enemyHealth = target.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public float setSpeed {
        get { return speed; }
        set { speed = value; }
    }

    public Vector3 setTargetPos
    {
        get { return targetPos; }
        set { targetPos = value; }
    }

    public int setDamage
    {
        get { return damage; }
        set { damage = value; }
    }
}
