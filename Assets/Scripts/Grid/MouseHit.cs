using UnityEngine;

public class MouseHit : MonoBehaviour {

    private GameObject target;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                hit.collider.SendMessage("MouseDown", SendMessageOptions.DontRequireReceiver);
                target = hit.collider.gameObject;
            }
        } else if (Input.GetMouseButtonUp(0) && target != null) {
            target.SendMessage("MouseUp", SendMessageOptions.DontRequireReceiver);
            target = null;
        }
    }
    
    public GameObject SetTarget {
        set { target = value; }
    }
    
}