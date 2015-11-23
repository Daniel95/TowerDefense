using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

    [SerializeField]
    private float horSpeed;

    [SerializeField]
    private float verSpeed;


    void FixedUpdate() {
        transform.Translate(horSpeed, verSpeed, 0);
    }
}
