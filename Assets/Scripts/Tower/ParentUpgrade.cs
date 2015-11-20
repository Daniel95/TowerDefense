using UnityEngine;

public class ParentUpgrade : MonoBehaviour
{
    private int pointsSpendOnThis;

    public Upgrades upgrades;

    public TextMesh text;

    void Start() {
        upgrades = transform.parent.GetComponent<Upgrades>();
        text = GetComponentInChildren<TextMesh>();
    }

    void MouseDown()
    {
        if (upgrades.PointsSpend <= upgrades.TotalPoints + 10)
        {
            UpgradeTower();
            upgrades.PointsSpend++;
            pointsSpendOnThis++;
            text.text = pointsSpendOnThis +  "/" + upgrades.TotalPoints;
        }
        print("spend = " + upgrades.PointsSpend);
        print("totalpoints = " + upgrades.TotalPoints);
    }

    public virtual void UpgradeTower() {

    }
}
