using UnityEngine;

public class Resources : MonoBehaviour {

    [SerializeField]
    private bool isTreeHouse;

    public bool checkTreeHouse {
        get { return isTreeHouse; }
    }
}
