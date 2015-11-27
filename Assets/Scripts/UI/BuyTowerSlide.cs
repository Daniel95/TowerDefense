using UnityEngine;

public class BuyTowerSlide : BuyTower {

    private BuyTower mainTowerShop;

    protected override void Awake()
    {
        base.Awake();
        mainTowerShop = GameObject.Find("Main Tower Shop").GetComponent<BuyTower>();
    }

    override protected void GetTower()
    {
        base.GetTower();
        mainTowerShop.NewSprite(selectedTower);
        mainTowerShop.ChangePrice(price);
    }
}
