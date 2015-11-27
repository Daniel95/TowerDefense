using UnityEngine;

public class HideSpriteOnAwake : MonoBehaviour {

    private SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
    }
}
