using UnityEngine;
using System.Collections;

public class BulletInfo : MonoBehaviour {

    private float speed;
    private Vector3 targetPos;
    private int damage;

    [SerializeField]
    private bool killSelf;

    private Animation anim;

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
            if(killSelf) Destroy(this.gameObject);
            
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
