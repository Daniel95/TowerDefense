using UnityEngine;

public class BuyTowerSlide : BuyTower {

    private BuyTower mainTowerShop;

    void Awake() {
        mainTowerShop = GameObject.Find("Main Tower Shop").GetComponent<BuyTower>();
    }

    public override void GetTower()
    {
        base.GetTower();
        int temp = selectedTower;
        selectedTower = mainTowerShop.selectedTower;
        mainTowerShop.selectedTower = temp;
        NewSprite();
        mainTowerShop.NewSprite();
    }
}
