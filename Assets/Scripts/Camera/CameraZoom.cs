using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float cameraDistanceMax;
    [SerializeField]
    private float cameraDistanceMin;
    [SerializeField]
    private float cameraDistance;
    [SerializeField]
    private float scrollSpeed;

    private Camera cam;


    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        //Using The ScrollingWheel to use the mouse zoom
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        cam.orthographicSize = cameraDistance;
    }
}