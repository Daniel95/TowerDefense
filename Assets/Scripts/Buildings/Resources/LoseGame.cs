using UnityEngine;
public class LoseGame : Health {

    protected override void Awake()
    {
        base.Awake();
        health = startHealth;
    }

    protected override void Die()
    {
        base.Die();
        Application.LoadLevel("Menu");
    }
}
