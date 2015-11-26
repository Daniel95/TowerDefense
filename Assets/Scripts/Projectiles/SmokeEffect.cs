using UnityEngine;
using System.Collections;

public class SmokeEffect : MonoBehaviour {

    [SerializeField]
    protected LayerMask checkLayer;

    private float maxEffectRadius;

    private float effectDamage;

    private float enemySlowedSpeed;

    void Awake() {
        StartCoroutine(Smoke());
    }

    IEnumerator Smoke()
    {
        print("smoke damage = " + effectDamage);
        print("smoke max radius = " + maxEffectRadius);
        print("smoke slow dividend = " + enemySlowedSpeed);

        //effect range starts at 0.3f
        float effectRange = 0.3f;
        //this effect lasts as long as it isnt bigger than maxEffectRange
        //maxEffectRange is set by the explosion depeding on the amount of upgrades the watchtower has.
        while (effectRange < 0.6f + maxEffectRadius) {
            //the effect gradualy grows bigger
            effectRange *= 1.003f;
            transform.localScale = new Vector3(effectRange, effectRange, 1);
            foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, effectRange, checkLayer)) {
                target.GetComponent<Health>().TakeDamage(effectDamage);
                target.GetComponent<FollowWayPoints>().SetMoveSpeed = enemySlowedSpeed;
            }
            yield return new WaitForFixedUpdate();
        }
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

    public float SetMaxRadius {
        set { maxEffectRadius = value; }    
    }

    public float SetDamage
    {
        set { effectDamage = value; }
    }

    public float SetSpeed
    {
        set { enemySlowedSpeed /= value; }
    }
}
