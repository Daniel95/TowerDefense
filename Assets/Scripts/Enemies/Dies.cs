using UnityEngine;
using System.Collections;

public class Dies : Health {

    private bool lastEnemy;

    protected Animator anim;

    override protected void Awake()
    {
        base.Awake();
        health = startHealth;
        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
        anim = GetComponent<Animator>();
    }

    protected override void Die()
    {
        base.Die();
        if (lastEnemy)
        {
            print("WaveOver");
            GameObject.Find("Start Wave").GetComponent<SpawnWave>().SetResourceCollection(false);
        }
        FollowWayPoints wayPoint = GetComponent<FollowWayPoints>();

        string animToPlay = "";

        int dir = (int)wayPoint.GetRotation;
        if (dir == 1) animToPlay = "DieUpView";
        else if (dir == 2 || dir == 4) animToPlay = "DieSideView";
        else if (dir == 3) animToPlay = "DieDownView";

        anim.Play(animToPlay);
        StartCoroutine(WaitForAnimation(animToPlay));
    }

    IEnumerator WaitForAnimation(string animName)
    {
        for (int i = 0; i <= 2; i++) {
            yield return new WaitForFixedUpdate();
        }
        //wait for animation to finish
        while (anim.GetCurrentAnimatorStateInfo(0).IsName(animName))
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(this.gameObject);
    }

    public bool LastEnemy {
        get { return lastEnemy; }
        set { lastEnemy = value; }
    }
}
