using UnityEngine;
using System.Collections;

public class ToggleGameobjectActive : MonoBehaviour {

    [SerializeField]
    private string objectName;

    private GameObject objectToToggle;

    private bool active;

    void Awake() {
        objectToToggle = GameObject.Find(objectName);
        objectToToggle.SetActive(active);
    }

    public void Toggle() {
        active = !active;
        objectToToggle.SetActive(active);
    }
}
