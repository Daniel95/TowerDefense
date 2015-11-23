using UnityEngine;
using UnityEngine.UI;


public class TotalResources : MonoBehaviour {

    [SerializeField]
    private int resources;

    private Text text;

    void Awake() {
        text = GetComponent<Text>();
        text.text = resources.ToString();
    }

    public void IncrementResources(int _increment) {
        resources += _increment;
        text.text = resources.ToString();
    }

    public void DecrementResources(int _decrement)
    {
        resources -= _decrement;
        text.text = resources.ToString();
    }

    public int GetResources {
        get { return resources; }
    }
}
