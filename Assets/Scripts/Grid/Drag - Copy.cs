using UnityEngine;
using System.Collections;

public class Dragcopy : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    private bool collision;

    private Vector2 startPos;

    private bool dragging;

    private Rigidbody2D rb;

    void Awake()
    {
        transform.position = SnapToGrid(transform.position);
    }

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
            //Debug.Log("backtostartdrag");
            transform.position = startPos;
            collision = false;
        }

        if (rb != null) Destroy(rb);
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        transform.position = SnapToGrid(curPosition);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            Debug.Log("enter other");
            collision = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            Debug.Log("exit other");
            collision = false;
        }
    }

    Vector3 SnapToGrid(Vector3 Position)
    {
        GameObject grid = GameObject.Find("gridsize");
        if (!grid)
            return Position;

        //	get position on the quad from -0.5...0.5 (regardless of scale)
        Vector3 gridPosition = grid.transform.InverseTransformPoint(Position);

        //	scale up to a number on the grid, round the number to a whole number, then put back to local size
        gridPosition.x = Mathf.Round(gridPosition.x);
        gridPosition.y = Mathf.Round(gridPosition.y);

        Position = grid.transform.TransformPoint(gridPosition);

        return Position;
    }
}
