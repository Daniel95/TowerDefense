using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{

    public GameObject[] WayPointsPad1;
    private int currentWaypoint = 0;

    //public GameObject[] WayPointsPad2;
    //   private int thisWayPoint = 0;

    [SerializeField]
    private float maxMoveSpeed;

    private float moveSpeed;

    private Vector3 playerPos;

    private Animator anim;

    private float rotation; 

    void Awake() {
        anim = GetComponent<Animator>();
        moveSpeed = maxMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSpeed < maxMoveSpeed) moveSpeed *= 1.1f;


        playerPos = this.transform.position;
        if (playerPos == WayPointsPad1[currentWaypoint].transform.position)
        {
            if (currentWaypoint == WayPointsPad1.Length - 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                currentWaypoint++;

                SetAnim();
            }
        }
        /*
        else if (playerPos == WayPointsPad2[thisWayPoint].transform.position)
        {
            if (currentWaypoint == WayPointsPad2.Length - 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                thisWayPoint++;
            }
        }*/

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), WayPointsPad1[currentWaypoint].transform.position, moveSpeed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), WayPointsPad2[thisWayPoint].transform.position, moveSpeed * Time.deltaTime);

        if (Random.value < 1)
        {

        }
        else
        {

        }
    }

    private void SetAnim() {
        rotation = (Mathf.Atan2(transform.position.y - WayPointsPad1[currentWaypoint].transform.position.y, WayPointsPad1[currentWaypoint].transform.position.x - transform.position.x) * 180 / Mathf.PI) + 180;

        rotation = (int)rotation / 90;
        if (rotation < 4)
        {
            anim.SetInteger("Direction", (int)rotation);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            anim.SetInteger("Direction", 2);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public float GetRotation {
        get { return rotation; }
    }

    public float SetMoveSpeed {
        set { moveSpeed *= value; }
    }
}