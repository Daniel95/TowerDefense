using UnityEngine;

public class Upgrades : MonoBehaviour {

    [SerializeField]
    private int totalPoints;

    private int pointsSpend;

    public int PointsSpend {
        set { pointsSpend += value; }
        get { return pointsSpend; }
    }

    public void IncrementPoint() {
        pointsSpend++;
    }

    public int TotalPoints
    {
        get { return totalPoints; }
    }
}
