using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {

	[SerializeField]
	private List <GameObject> paden;
	//public GameObject[] WayPointsPad1;
	public GameObject splitsing;
	public GameObject padA;
	public GameObject padB;
	public GameObject padA2;
	public GameObject end;

	private int currentWaypoint = 0;
	private float random;

	//public GameObject[] WayPointsPad2;
	//private int thisWayPoint = 0;


	void Start()
	{
		paden = new List<GameObject> ();

		paden.Add (splitsing);

		random = Random.Range (0, 2);
		print (random);

		if (random == 1) {
			paden.Add (padA);
			paden.Add (padA2);
			paden.Add (end);
		} else {
			paden.Add (padB);
			paden.Add (end);
		}

	}


	public float moveSpeed = 1.0f;
	private Vector3 playerPos;

	// Update is called once per frame
	void Update () 
	{
		float step = moveSpeed * Time.deltaTime;
		playerPos = this.transform.position;

		if (playerPos == paden [currentWaypoint].transform.position) 
		{
			if (currentWaypoint == paden.Count - 1) 
			{
				Destroy (this.gameObject);
			} 
			else 
			{
				currentWaypoint++;
			}
		}

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), paden[currentWaypoint].transform.position, step);




	
	}
}