using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	private int score = 0;

	[SerializeField]
	private GameObject gameobject;
	private int increase = 20;
	
	void Awake () {
		InvokeRepeating("AddScore", 0, 3);
	}
	void AddScore () {
		score += increase;

		Debug.Log ("Total: " + score);


	}

}