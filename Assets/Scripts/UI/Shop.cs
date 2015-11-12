using UnityEngine;

public class Shop : MonoBehaviour {

    [SerializeField]
    private GameObject[] towers;

    private int selectedTower = 0;

    private MouseHit mouse;

    void Awake() {
        mouse = GameObject.Find("Main Camera").GetComponent<MouseHit>();
    }

    public void BuyTower()
    {
        //transfer the mouse position to the world position
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 startDragPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //spawn the selected tower
        GameObject tower = Instantiate(towers[selectedTower], startDragPos, transform.rotation) as GameObject;
        //set the right start properties of the tower, so it knows its being dragged.
        Drag drag = tower.GetComponent<Drag>();
        drag.SetStartPosition = startDragPos;
        drag.SetKinematic = false;
        mouse.SetTarget = drag;
    }
}
