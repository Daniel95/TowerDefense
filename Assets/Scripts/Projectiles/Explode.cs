using UnityEngine;

public class Explode : Timer {

    [SerializeField]
    private GameObject smoke;

    //private int smokeUpgrades;

    private float smokeRadius;

    private int smokeDamage;

    private float smokeSpeedDividend;

    public override void TimerOver()
    {
        base.TimerOver();

        //spawn smoke
        GameObject smokeObject = Instantiate(smoke, transform.position, transform.rotation) as GameObject;
        SmokeEffect smokeEffect = smokeObject.GetComponent<SmokeEffect>();
        smokeEffect.SetMaxRadius = smokeRadius;//1 + smokeUpgrades / 4;
        smokeEffect.SetDamage = smokeDamage;//0.05f + smokeUpgrades / 30;
        smokeEffect.SetSlow = smokeSpeedDividend;//0.006f - smokeUpgrades / 800;

        Destroy(this.gameObject);
    }

    public int SetSmokeDamage
    {
        set { smokeDamage = value; }
    }

    public float SetSmokeRadius
    {
        set { smokeRadius = value; }
    }

    public float SetSpeedDividend
    {
        set { smokeSpeedDividend = value; }
    }
}
