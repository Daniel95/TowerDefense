using UnityEngine;
using UnityEngine.UI;

public class CollectResources : MonoBehaviour {

    [SerializeField]
    private bool colletingResources;

    [SerializeField]
    private float incrementCooldown;

    [SerializeField]
    private int increaseResources;

    [SerializeField]
    private GameObject textSpawnPoint;

    [SerializeField]
    private TextMesh incrementText;

    private TotalResources totalResources;

    void Awake()
    {
        totalResources = GameObject.Find("Total Resources").GetComponent<TotalResources>();
        InvokeRepeating("AddScore", 0, incrementCooldown);
    }

    void AddScore()
    {
        if (colletingResources) {
            totalResources.IncrementResources(increaseResources);
            SpawnText();
        }
    }

    void SpawnText()
    {
        TextMesh text = Instantiate(incrementText, textSpawnPoint.transform.position, transform.rotation) as TextMesh;
        text.text = "+ " + increaseResources.ToString();
    }

    public bool CollectingResources {
        set { colletingResources = value; }
        get { return colletingResources; }
    }
}
