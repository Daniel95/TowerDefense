using UnityEngine;

public class DetectTarget : MonoBehaviour {

    [SerializeField]
    protected LayerMask checkLayer;

    [SerializeField]
    protected float cooldown;

    protected float range;

    private Transform rangeIndicator;

    private GameObject currentEnemy;

    protected Animator anim;

    virtual protected void Awake() {
        float startRandom = Random.Range(0, 0.99f);
        anim = GetComponent<Animator>();
        rangeIndicator = transform.FindChild("ShootRange");
        range = rangeIndicator.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        InvokeRepeating("CheckForTarget", startRandom, cooldown);
    }

    virtual protected void CheckForTarget()
    {

    }

    public float SetCooldown {
        set { cooldown /= value; }
    }

    public void UpgradeRange(float increment) {
        rangeIndicator.localScale = new Vector3(rangeIndicator.localScale.x + increment, rangeIndicator.localScale.y  + increment, rangeIndicator.localScale.z);
        print(rangeIndicator.GetComponent<SpriteRenderer>().bounds.size.x / 2);
        range += increment * 2;
        print("range: " + range);
    }
}
