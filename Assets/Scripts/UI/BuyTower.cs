using UnityEngine;
using UnityEngine.UI;

public class BuyTower : MonoBehaviour {

    [SerializeField]
    private Sprite[] towerButtonSprites;

    [SerializeField]
    private GameObject[] towers;

    public int selectedTower = 0;

    private bool clickable = true;

    private MouseHit mouse;

    private Image image;

    void Start() {
        mouse = GameObject.Find("Main Camera").GetComponent<MouseHit>();
        image = GetComponent<Image>();
        image.sprite = towerButtonSprites[selectedTower];
    }

    public virtual void GetTower()
    {
        if (clickable)
        {
            //transfer the mouse position to the world position
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 startDragPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z ));
            //spawn the selected tower
            GameObject tower = Instantiate(towers[selectedTower], startDragPos, transform.rotation) as GameObject;
            //set the right start properties of the tower, so it knows its being dragged.

            mouse.SetTarget = tower;
            Drag drag = tower.GetComponent<Drag>();
            drag.StartDrag();
            drag.SetKinematic = false;
        }
    }

    public void NewSprite() {
        image.sprite = towerButtonSprites[selectedTower];
    }

    public bool SetClickable {
        set { clickable = value; }
        get { return clickable;  }
    }
}
