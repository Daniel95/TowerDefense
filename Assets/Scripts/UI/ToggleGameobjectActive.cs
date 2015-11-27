using UnityEngine;

public class ToggleGameobjectActive : MonoBehaviour {

    [SerializeField]
    private GameObject objectToToggle;

    [SerializeField]
    private bool active;

    void Awake() {
        objectToToggle.SetActive(active);
    }

    public void ToggleFromButton() {
        active = !active;
        objectToToggle.SetActive(active);
    }

    public void ToggleFromScript(bool _active) {
        active = _active;
        objectToToggle.SetActive(_active);
    }
}
