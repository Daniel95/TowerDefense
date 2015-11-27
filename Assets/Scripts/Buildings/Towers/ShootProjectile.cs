using UnityEngine;

public class ShootProjectile : TargetClosest {

    [SerializeField]
    protected GameObject projectile;

    [SerializeField]
    protected float projectileSpeed;

    [SerializeField]
    protected int damage;

    protected GameObject bullet;

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
        bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        BulletInfo bulletinfo = bullet.GetComponent<BulletInfo>();
        bulletinfo.setSpeed = projectileSpeed;
        bulletinfo.setTargetPos = targetPos;
        bulletinfo.setDamage = damage;
    }

    public void UpgradeDamage(int _upgrade) {
        damage += _upgrade;
    }
}
