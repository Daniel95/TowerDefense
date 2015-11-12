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

    private GameObject currentEnemy;

    void Awake() {

        float random = Random.Range(0, 0.99f);
        range = transform.Find("TowerRange").GetComponent<SpriteRenderer>().bounds.size.x / 2;
        InvokeRepeating("CheckForEnemy", random, cooldown);
    }

    void CheckForEnemy()
    {
        float shortestDist = 1000;
        Vector3 EnemyPos = new Vector3();

        foreach (Collider2D enemy in Physics2D.OverlapCircleAll(transform.position, range, checkLayer)) {
            float distanceToEnemy = Vector3.Distance(enemy.gameObject.transform.position, transform.position);
            if (distanceToEnemy < shortestDist)
            {
                shortestDist = distanceToEnemy;
                EnemyPos = enemy.transform.position;
            }
        }
        if (shortestDist < 1000)
        {
            if (EnemyPos.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            } else {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Shoot(EnemyPos);
        }
    }

    void Shoot(Vector3 enemyPos) {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            BulletInfo bulletinfo = bullet.GetComponent<BulletInfo>();
            bulletinfo.setSpeed = projectileSpeed;
            bulletinfo.setTargetPos = enemyPos;
            bulletinfo.setDamage = damage;
        }
    }
