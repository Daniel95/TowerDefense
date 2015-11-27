using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{

    [SerializeField]
    private Camera cam;
    private float cameraDistanceMax = -6f;
    private float cameraDistanceMin = -10f;
    private float cameraDistance = -7.5f;
    private float scrollSpeed = 2f;

    void Update()
    {
        //Using The ScrollingWheel to use the mouse zoom
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        //Debug.Log(cameraDistance);

        //set Camera postion
        cam.orthographicSize = cameraDistance;

        /*
		//cam.transform.position = cameraDistance;
		Vector3 tempCamPos = cam.transform.position;
		tempCamPos.z = cameraDistance;
		cam.transform.position = tempCamPos;
		//cam.transform.position = cameraDistance;
		print (cam.transform.position.z);
		*/
    }
}