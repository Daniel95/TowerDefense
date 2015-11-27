using UnityEngine;

public class Explode : Timer {

    [SerializeField]
    private GameObject smoke;

    private float smokeRadius;

    private float smokeDamage;

    private float smokeSpeedDivide;

    public override void TimerOver()
    {
        base.TimerOver();

        //smokeRadius, smokeDamage & smokeSpeedDivide is given by ShootSmokeBomb script. (the tower that shoots)
        //when the timer expires the bomb explodes. 
        //and this object spawns smoke
        GameObject smokeObject = Instantiate(smoke, transform.position, transform.rotation) as GameObject;
        SmokeEffect smokeEffect = smokeObject.GetComponent<SmokeEffect>();
        smokeEffect.StartSmoke(smokeRadius, smokeDamage, smokeSpeedDivide);

        Destroy(this.gameObject);
    }

    public float SetSmokeDamage
    {
        set { smokeDamage = value; }
    }

    public float SetSmokeRadius
    {
        set { smokeRadius = value; }
    }

    public float SetSpeedDivide
    {
        set { smokeSpeedDivide = value; }
    }
}
