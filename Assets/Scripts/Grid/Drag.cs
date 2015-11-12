using UnityEngine;
using System.Collections;

public class Drag : Snap {

    private Vector3 screenPoint;
    private Vector3 offset;

    //stores the position on mouse down,
    //returns to this location on mousse up and the object is still coliding after snapped to the grid.
    private Vector2 startPos;

    private bool collision;

    private SpriteRenderer rangeIndicator;

    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        rangeIndicator = transform.Find("TowerRange").GetComponent<SpriteRenderer>();
        if(rangeIndicator != null) rangeIndicator.enabled = false;
    }

    public virtual void OnClick()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        startPos = transform.position;

        rb.isKinematic = false;
        if (rangeIndicator != null) rangeIndicator.enabled = true;
    }

    public virtual void OnPlace() {
        if (collision)
        {
            transform.position = startPos;
            collision = false;
        }

        rb.isKinematic = true;
        if (rangeIndicator != null) rangeIndicator.enabled = false;
    }

    public void OnDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = SnapToGrid(curPosition);
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

    public Vector3 SetStartPosition {
        set { startPos = value; }
    }

    public bool SetKinematic
    {
        set { rb.isKinematic = value; }
    }
}
