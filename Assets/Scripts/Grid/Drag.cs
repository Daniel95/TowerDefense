using UnityEngine;
using System.Collections;

public class Drag : Snap {

    [SerializeField]
    private bool placed;

    private Vector3 screenPoint;
    private Vector3 offset;

    //stores the position on mouse down,
    //returns to this location on mousse up and the object is still coliding after snapped to the grid.
    private Vector2 startPos;

    private bool collision;

    private GameObject rangeIndicator;

    private GameObject upgradeMenu;

    private Rigidbody2D rb;

    private bool dragging;

    private bool showUpgrades;

    private bool showRange;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        rangeIndicator = transform.Find("TowerRange").gameObject;
        if(rangeIndicator != null) rangeIndicator.SetActive(false);
        upgradeMenu = transform.Find("UpgradeMenu").gameObject;
        if (upgradeMenu != null) upgradeMenu.SetActive(false);
    } 

    private void Upgrade() {
        showUpgrades = !showUpgrades;
        upgradeMenu.SetActive(showUpgrades);
        if (rangeIndicator != null)
        {
            showRange = !showRange;
            rangeIndicator.SetActive(showRange);
        }
    }

    private void MouseDown() {
        if (placed) Upgrade();
        else StartDrag();
    }

    public void StartDrag()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        startPos = transform.position;

        rb.isKinematic = false;
        if (rangeIndicator != null) rangeIndicator.SetActive(true);

        dragging = true;
       //StartCoroutine(Dragging());
    }

    private void MouseUp()
    {
        if (!placed) {
            if (!collision) {
                dragging = false;
                placed = true;

                rb.isKinematic = true;
                if (rangeIndicator != null) rangeIndicator.SetActive(false);
            }
         }
    }
    
    void Update() {
        if (dragging) Dragging();
    }

    /*
    IEnumerator Dragging()
    {
        print("dragging");
        while(1 == 1) {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = SnapToGrid(curPosition);

            if (rangeIndicator != null)
            {
                if (collision) rangeIndicator.SetActive(false);
                else rangeIndicator.SetActive(true);
            }
            yield return new WaitForFixedUpdate();
        }
    }*/
    
    private void Dragging()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = SnapToGrid(curPosition);

        if (rangeIndicator != null)
        {
            if (collision) rangeIndicator.SetActive(false);
            else rangeIndicator.SetActive(true);
        }

    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tile")
        {
            collision = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tile")
        {
            collision = false;
        }
    }

    public bool getPlaced {
        get { return placed; }
    }

    public Vector3 SetStartPosition {
        set { startPos = value; }
    }

    public bool SetKinematic
    {
        set { rb.isKinematic = value; }
    }
}
