using UnityEngine;
using System.Collections;

public class LoseGame : Health {

    private HealthText healthText;

    private Animator anim;

    protected override void Awake()
    {
        anim = GetComponent<Animator>();
        healthText = GameObject.Find("Lives Text").GetComponent<HealthText>();

        base.Awake();
        health = startHealth;
        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        healthText.SetText(health);
    }

    IEnumerator WaitForAnimation(string animName)
    {
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        //wait for animation to finish
        while (anim.GetCurrentAnimatorStateInfo(0).IsName(animName))
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(this.gameObject);
    }

    protected override void Dead()
    {
        base.Dead();
        anim.Play("ThreeHouseDestruction");
        StartCoroutine(WaitForAnimation());
        GetComponent<ToggleGameobjectActive>().ToggleFromScript(true);
    }

    IEnumerator WaitForAnimation()
    {
        for (int i = 0; i <= 310; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        Time.timeScale = 0;
    }
}