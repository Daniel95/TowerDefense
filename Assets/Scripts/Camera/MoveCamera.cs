using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    [SerializeField]
    private float cameraMoveSpeed;

    private int screenHeight, screenWidth;

    private float moveHor, moveVert;

    private float upMoveZone , downMoveZone, leftMoveZone, rightMoveZone;

    [SerializeField]
    private float upperBorder, downBorder, leftBorder, rightBorder;

	// Use this for initialization
	void Awake () {
        screenHeight = Screen.height;
        screenWidth = Screen.width;


        leftMoveZone = screenWidth / 20;
        rightMoveZone = screenWidth / 1.05f;
        downMoveZone = screenHeight / 20;
        upMoveZone = screenHeight / 1.05f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.x < leftMoveZone && leftBorder < transform.position.x) moveHor -= cameraMoveSpeed;
        else if(Input.mousePosition.x > rightMoveZone && rightBorder > transform.position.x) moveHor += cameraMoveSpeed;
        if (Input.mousePosition.y < downMoveZone && downBorder < transform.position.y) moveVert -= cameraMoveSpeed;
        else if (Input.mousePosition.y > upMoveZone && upperBorder > transform.position.y) moveVert += cameraMoveSpeed;
        transform.position = new Vector3(moveHor, moveVert, -10);
    }
}
