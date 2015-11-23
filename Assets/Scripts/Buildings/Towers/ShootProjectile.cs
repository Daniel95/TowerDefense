using UnityEngine;

public class ShootProjectile : TargetClosest {

    [SerializeField]
    protected GameObject projectile;

    [SerializeField]
    protected float projectileSpeed;

    [SerializeField]
    protected int damage;

    private Drag drag;

    protected override void Awake()
    {
        base.Awake();
        drag = gameObject.GetComponent<Drag>();
    }

    protected override void Shoot(Vector3 targetPos)
    {
        base.Shoot(targetPos);
        if (drag.getPlaced)
        {
            FireProjectile(targetPos);
        }
    }

    protected virtual void FireProjectile(Vector3 targetPos) {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        BulletInfo bulletinfo = bullet.GetComponent<BulletInfo>();
        bulletinfo.setSpeed = projectileSpeed;
        bulletinfo.setTargetPos = targetPos;
        bulletinfo.setDamage = damage;
    }

    public int SetDamage
    {
        set { damage += value; }
    }
}
