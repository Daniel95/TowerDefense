using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Points : MonoBehaviour {

	private int totalScore = 0;
	public Text countText;
	public Text totalText;

	[SerializeField]
	private int increaseScore = 20;

	
	void Awake () 
	{
		InvokeRepeating("AddScore", 0, 3f);
		SetText ();
	}

	void AddScore () {
		totalScore += increaseScore;

		Debug.Log ("Total: " + totalScore);
		SetText ();

	}

	void SetText ()
	{
		countText.text = "+ " + increaseScore.ToString ();
		totalText.text = "Resource Points: " + totalScore.ToString ();
	}

}