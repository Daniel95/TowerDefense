using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    private int cooldown;

	// Use this for initialization
	void Awake () {
        InvokeRepeating("TimerOver", cooldown, cooldown);
    }

    public virtual void TimerOver() {

    }
}
