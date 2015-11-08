using UnityEngine;
using System.Collections;

public class ShowRangeOnDrag : MonoBehaviour {

    private SpriteRenderer rangeIndicator;

	// Use this for initialization
	void Awake () {
        rangeIndicator = transform.Find("TowerRange").GetComponent<SpriteRenderer>();
        rangeIndicator.enabled = false;
	}

    void OnMouseDown()
    {
        rangeIndicator.enabled = true;
    }

    void OnMouseUp()
    {
        rangeIndicator.enabled = false;
    }
}
