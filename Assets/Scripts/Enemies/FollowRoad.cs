using UnityEngine;

public class FollowRoad : MonoBehaviour {

    [SerializeField]
    private float maxMoveSpeed;

    private float moveSpeed;

    void Awake() {
        moveSpeed = maxMoveSpeed;
    }

	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, moveSpeed, 0);
        if (moveSpeed < maxMoveSpeed) moveSpeed *= 1.1f;
    }

    public float SetMoveSpeed {
        set { moveSpeed = value; }
    }
}
