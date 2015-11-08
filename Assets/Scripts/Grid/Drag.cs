using UnityEngine;
using System.Collections;

public class Drag : Snap {

    private Vector3 screenPoint;
    private Vector3 offset;

    //stores the position on mouse down,
    //returns to this location on mousse up and the object is still coliding after snapped to the grid.
    private Vector2 startPos;

    private bool collision;

    private Rigidbody2D rb;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        startPos = transform.position;
    }

    void OnMouseUp()
    {
        if (collision)
        {
            transform.position = startPos;
            collision = false;
        }

        if (rb != null) Destroy(rb);
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        transform.position = SnapToGrid(curPosition);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tile") collision = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tile") collision = false;
    }
}
