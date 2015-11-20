using UnityEngine;
using System.Collections;

public class UpgradeText : MonoBehaviour {
    
    public string SortingLayerName = "Default";
    public int SortingOrder = 0;

    void Awake()
    {
       gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
       gameObject.GetComponent<MeshRenderer>().sortingOrder = 50;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
