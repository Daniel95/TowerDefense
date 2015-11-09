using UnityEngine;
using System.Collections;

public class FollowRoad : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

	// Update is called once per frame
	void Update () {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
}
