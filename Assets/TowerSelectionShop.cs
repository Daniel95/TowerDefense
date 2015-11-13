using UnityEngine;
using System.Collections;

public class TowerSelectionShop : Shop {

    [SerializeField]
    private GameObject selectTowerButton;

    private Shop selectTowerShop;

    void Awake() {
        selectTowerShop = selectTowerButton.GetComponent<Shop>();
    }

    public override void BuyTower() {
        base.BuyTower();
        int temp = selectedTower;
        selectedTower = selectTowerShop.selectedTower;
        selectTowerShop.selectedTower = temp;
    }
}
