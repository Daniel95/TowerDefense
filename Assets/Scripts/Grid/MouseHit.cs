using UnityEngine;
using System.Collections;

public class MouseHit : MonoBehaviour {

    private Drag target;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Drag drag = hit.collider.GetComponent<Drag>();
                if (drag != null)
                {
                    target = drag;
                    target.OnClick();
                }
            }
        }
        else if (target != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                target.OnPlace();
                target = null;
            }
            else
            {
                target.OnDrag();
            }
        }
    }

    public Drag SetTarget {
        set { target = value; }
    }
}