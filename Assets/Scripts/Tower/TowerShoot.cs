using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerShoot : MonoBehaviour {

    [SerializeField]
    private LayerMask checkLayer;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private int damage;

    private float range;

    private Transform rangeIndicator;

    private GameObject currentEnemy;

    private Drag drag;

    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
        drag = gameObject.GetComponent<Drag>();
        rangeIndicator = transform.FindChild("TowerRange");
        range = rangeIndicator.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        InvokeRepeating("CheckForEnemy", 0, cooldown);
    }

    void CheckForEnemy()
    {
        float shortestDist = range;
        Vector3 EnemyPos = new Vector3();

        foreach (Collider2D enemy in Physics2D.OverlapCircleAll(transform.position, range, checkLayer))
        {
            float distanceToEnemy = Vector3.Distance(enemy.gameObject.transform.position, transform.position);
            if (distanceToEnemy < shortestDist)
            {
                shortestDist = distanceToEnemy;
                EnemyPos = enemy.transform.position;
            }
        }
        if (shortestDist < range) {


            if (EnemyPos.y > transform.position.y) anim.SetBool("FaceToFront", false);
            else anim.SetBool("FaceToFront", true);

            if (EnemyPos.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                foreach (Transform child in transform)
                {
                    child.localScale = new Vector3(-1, 1, 1);
                }
            } else {
                transform.localScale = new Vector3(1, 1, 1);
                foreach (Transform child in transform)
                {
                    child.localScale = new Vector3(1, 1, 1);
                }
            }
            Shoot(EnemyPos);
        }
    }

    void Shoot(Vector3 enemyPos) {
        if (drag.getPlaced)
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            BulletInfo bulletinfo = bullet.GetComponent<BulletInfo>();
            bulletinfo.setSpeed = projectileSpeed;
            bulletinfo.setTargetPos = enemyPos;
            bulletinfo.setDamage = damage;
            //anim.SetBool()
        }
    }

    public int SetDamage {
        set { damage += value; }
    }

    public float SetCooldown {
        set { cooldown -= value; }
    }

    public void UpgradeRange(float increment) {
        rangeIndicator.localScale = new Vector3(rangeIndicator.localScale.x + increment, rangeIndicator.localScale.y  + increment, rangeIndicator.localScale.z);
        range += increment * 2;
        print(range);
    }
}
