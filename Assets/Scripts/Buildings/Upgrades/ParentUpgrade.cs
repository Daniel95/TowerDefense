using UnityEngine;

public class ParentUpgrade : MonoBehaviour
{
    private int price;

    protected int pointsSpendOnThis;

    protected Upgrades upgrades;

    private TotalResources totalResources;

    protected virtual void Awake() {
        upgrades = transform.parent.GetComponent<Upgrades>();
        totalResources = GameObject.Find("Total Resources").GetComponent<TotalResources>();
        foreach (Transform textObj in transform)
        {
            if (textObj.gameObject.name == "Points") {
                textObj.GetComponent<TextMesh>().text = pointsSpendOnThis + "/" + upgrades.TotalPoints;
            }
            else if (textObj.gameObject.name == "Price") {
                price = int.Parse(textObj.GetComponent<TextMesh>().text);
            }
        }
    }

    private void MouseDown()
    {
        if (totalResources.GetResources > price && upgrades.PointsSpend < upgrades.TotalPoints)
        {
            totalResources.DecrementResources(price);
            UpgradeTower();
            upgrades.IncrementPoint();
            pointsSpendOnThis++;
            SetPointsText();
        }
    }

    public virtual void SetPointsText() {
        foreach (Transform textObj in transform)
        {
            if (textObj.gameObject.name == "Points")
            {
                textObj.GetComponent<TextMesh>().text = pointsSpendOnThis + "/" + upgrades.TotalPoints;
            }
        }
    }

    protected virtual void UpgradeTower() {

    }
}
