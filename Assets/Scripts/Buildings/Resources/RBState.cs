using UnityEngine;

public class RBState : Health {

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private float healthRecoverRate;

    [SerializeField]
    private float healthRecoverAmount;

    [SerializeField]
    private Sprite[] resourceImages;

    private SpriteRenderer sprite;

    private CollectResources collectResources;

    private Upgrades upgrades;

    private GameObject upgradeMenu;

    private UpgradeResource upgradeResource;

    private bool MenuActive;

    protected override void Awake()
    {
        base.Awake();
        upgradeResource = GetComponentInChildren<UpgradeResource>();
        upgrades = GetComponentInChildren<Upgrades>();
        collectResources = GetComponent<CollectResources>();
        sprite = GetComponent<SpriteRenderer>();
        

        upgradeMenu = transform.Find("UpgradeMenu").gameObject;
        upgradeMenu.SetActive(false);

        InvokeRepeating("RecoverHealth", 0, healthRecoverRate);
    }

    protected override void Dead()
    {
        base.Dead();
        if (collectResources.CollectingResources)
        {
            collectResources.CollectingResources = false;
            upgrades.PointsSpend = 0;
            upgradeResource.SetPointSpendOnThis = 0;
            upgradeResource.SetPointsText();
            sprite.sprite = resourceImages[0];
        }
    }

    private void RecoverHealth() {
        if (collectResources.CollectingResources)
        {
            if (health < maxHealth) health += healthRecoverAmount;
            healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
        }
    }

    public void UpgradeRB() {
        collectResources.CollectingResources = true;
        health = startHealth;
        healthbar.localScale = new Vector3(health * startScale / startHealth, 1, 1);
        sprite.sprite = resourceImages[1];
    }

    void MouseDown() {
        MenuActive = !MenuActive;
        upgradeMenu.SetActive(MenuActive);
    }
}
