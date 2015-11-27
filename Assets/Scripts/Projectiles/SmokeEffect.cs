using UnityEngine;
using System.Collections;

public class SmokeEffect : MonoBehaviour {

    [SerializeField]
    protected LayerMask checkLayer;

    private float maxEffectRadius;

    private float effectDamage;

    private float enemyDivideSpeed;

    IEnumerator Smoke()
    {
        //effect range starts at 0.3f
        float effectRange = 0.3f;
        //this effect lasts as long as it isnt bigger than maxEffectRange
        //maxEffectRange is set by the explode script depeding on the amount of upgrades the watchtower has.

        while (effectRange < maxEffectRadius) {


            //the effect gradualy grows bigger
            effectRange *= 1.003f;
            transform.localScale = new Vector3(effectRange, effectRange, 1);
            foreach (Collider2D target in Physics2D.OverlapCircleAll(transform.position, effectRange, checkLayer)) {
                target.GetComponent<Health>().TakeDamage(effectDamage);
                target.GetComponent<FollowWayPoints>().DivideSpeed(enemyDivideSpeed);
            }
            yield return new WaitForFixedUpdate();
        }
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

    public void StartSmoke(float rad, float dmg, float speed) {
        maxEffectRadius = rad;
        effectDamage = dmg;
        enemyDivideSpeed = speed;

        StartCoroutine(Smoke());
    }
    /*
    public float SetMaxRadius {
        set { maxEffectRadius = value; }    
    }

    public float SetDamage
    {
        set { effectDamage = value; }
    }

    public float SetSpeedDivide
    {
        set { enemyDivideSpeed = value; }
    }*/
}
