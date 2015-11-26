using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField]
    private List<List<GameObject>> PathToFollow;

    private List<GameObject> currentPath; 

    private int currentPathNumber = 0;

    private int currentWaypointNumber = 0;

    [SerializeField]
    private float maxMoveSpeed;

    private float moveSpeed = 1;

    private Animator anim;

    private float rotation;

    private Vector3 myPosition;

    private WayPointsData data;

    private bool pathChosen;

    public void ChoosePath(int _pathNumber) {

        anim = GetComponent<Animator>();

        data = GameObject.Find("PathData").GetComponent<WayPointsData>();
        PathToFollow = new List<List<GameObject>>();

        moveSpeed = maxMoveSpeed;

        if (_pathNumber == 0)
        {//RIGHT PATH
            PathToFollow.Add(data.PR1);

            float split1 = Random.Range(0, 0.99f);
            if (split1 < 0.50f)
            {//RIGHT PATH FIRST UP
                PathToFollow.Add(data.PR2A);
                float split2 = Random.Range(0, 0.99f);
                if (split2 < 0.50f)
                {//RIGHT PATH SECOND UP DOWN
                    PathToFollow.Add(data.PR3B);
                    PathToFollow.Add(data.PR4);
                    PathToFollow.Add(data.End);
                }
                else //RIGHT PATH SECOND STRAIGHT DOWN
                {
                    PathToFollow.Add(data.PR3A1);
                    PathToFollow.Add(data.PR3A2);
                    PathToFollow.Add(data.PR4);
                    PathToFollow.Add(data.End);
                }
            }
            //RIGHT PATH FIRST DOWN
            else
            {
                PathToFollow.Add(data.PR2B1);
                PathToFollow.Add(data.PR2B2);
                PathToFollow.Add(data.PR3A2);
                PathToFollow.Add(data.PR4);
                PathToFollow.Add(data.End);
            }
        }
        else
        { //LEFT PATH
            PathToFollow.Add(data.PL1);

            float split1 = Random.Range(0, 0.99f);
            //LEFT PATH FIRST LEFT
            if (split1 < 0.50f)
            {
                PathToFollow.Add(data.PL2B);
                PathToFollow.Add(data.PL3A2);
                PathToFollow.Add(data.End);
            }
            //LEFT PATH FIRST RIGHT
            else
            {
                PathToFollow.Add(data.PL2A);
                float split2 = Random.Range(0, 0.99f);
                if (split2 < 0.50f) //LEFT PATH SECOND UP
                {
                    PathToFollow.Add(data.PL3A1);
                    PathToFollow.Add(data.PL3A2);
                    PathToFollow.Add(data.End);
                }
                else //LEFT PATH SECOND DOWN
                {
                    PathToFollow.Add(data.PL3B);
                    PathToFollow.Add(data.PR2B2);
                    PathToFollow.Add(data.PR3A2);
                    PathToFollow.Add(data.PR4);
                    PathToFollow.Add(data.End);
                }
            }
        }

        currentPath = PathToFollow[currentPathNumber];
        SetAnim();
        pathChosen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathChosen)
        {
            if (moveSpeed < maxMoveSpeed) moveSpeed *= 1.05f;

            if (transform.position == currentPath[currentWaypointNumber].transform.position)
            {
                if (currentWaypointNumber == currentPath.Count - 1)
                {
                    if (currentPathNumber == PathToFollow.Count - 1)
                    {
                        Destroy(this.gameObject);
                    }
                    //increase the pathnumber for pathToFollow
                    currentPathNumber++;
                    //set the current path as the new path in pathToFollow
                    currentPath = PathToFollow[currentPathNumber];
                    //start counting from 0 (first waypoint) in the new path.
                    currentWaypointNumber = 0;
                    //Update Animation To Play
                    SetAnim();
                }
                else
                {
                    //Go To The Next Waypoint in CurrentWayPoint
                    currentWaypointNumber++;
                    SetAnim();
                }
            }
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentPath[currentWaypointNumber].transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void SetAnim()
    {
        rotation = (Mathf.Atan2(transform.position.y - currentPath[currentWaypointNumber].transform.position.y, currentPath[currentWaypointNumber].transform.position.x - transform.position.x) * 180 / Mathf.PI) + 180;

        //print(rotation);

        rotation = Mathf.RoundToInt(rotation / 90);

        //rotation = (int)rotation / 90;

        //print(rotation);
        //print(currentPath[currentWaypointNumber].transform.position);

        if (rotation == 0) rotation = 4;

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

    public void DivideSpeed(float dividend)
    {
        moveSpeed = maxMoveSpeed / dividend;
    }

    public float GetRotation
    {
        get { return rotation; }
    }

    public float SetMoveSpeedMultiply
    {
        set { moveSpeed *= value; }
    }
}
