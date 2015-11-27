using UnityEngine;
using UnityEngine.UI;

public class BuyTower : MonoBehaviour {

    [SerializeField]
    private Sprite[] towerButtonSprites;

    [SerializeField]
    private GameObject[] towers;

    [SerializeField]
    protected int selectedTower;

    protected int price;

    private bool clickable = true;

    private MouseHit mouse;

    private Image shopImage;

    private GameObject UnitInfoToDisplay;

    private TotalResources totalResources;

    protected virtual void Awake() {
        totalResources = GameObject.Find("Total Resources").GetComponent<TotalResources>();
        mouse = GameObject.Find("Main Camera").GetComponent<MouseHit>();
        shopImage = GetComponent<Image>();
        shopImage.sprite = towerButtonSprites[selectedTower];
        foreach (Transform obj in transform)
        {
            if (obj.gameObject.name == "Price")
            {
                price = int.Parse(obj.GetComponent<Text>().text);
            } else if (obj.tag == "Hover") {
                obj.gameObject.SetActive(false);
            }
        }
    }

    public void HoverEnter() {
        if (clickable)
        {
            UnitInfoToDisplay = transform.Find("UnitInfo" + selectedTower).gameObject;
            UnitInfoToDisplay.SetActive(true);
        }
    }

    public void HoverExit() {
        if (clickable)
        {
            UnitInfoToDisplay.SetActive(false);
        }
    }

    public void CheckRequirements() {
        if (clickable && totalResources.GetResources >= price)
        {
            totalResources.DecrementResources(price);
            GetTower();
        }
    }

    protected virtual void GetTower()
    {
        //transfer the mouse position to the world position
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 startDragPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //spawn the selected tower
        GameObject tower = Instantiate(towers[selectedTower], startDragPos, transform.rotation) as GameObject;
        //set the right start properties of the tower, so it knows its being dragged.

        mouse.SetTarget = tower;
        Drag drag = tower.GetComponent<Drag>();
        drag.StartDrag();
        drag.SetKinematic = false;
    }

    public void NewSprite(int _unit) {
        selectedTower = _unit;
        shopImage.sprite = towerButtonSprites[selectedTower];
    }

    public bool SetClickable {
        set { clickable = value; }
        get { return clickable;  }
    }

    public int Selected {
        get { return selectedTower; }
        set { selectedTower = value; }
    }

    public void ChangePrice(int _newPrice) {
        price = _newPrice;
        foreach (Transform obj in transform)
        {
            if (obj.gameObject.name == "Price")
            {
                obj.GetComponent<Text>().text = price.ToString();
            }
        }
    }
}
