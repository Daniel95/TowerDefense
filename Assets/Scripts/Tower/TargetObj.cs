using UnityEngine;
using System.Collections;

public class TargetObj : MonoBehaviour {

    public virtual void SeeEnemy(GameObject _enemy)
    {

    }
    /*
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            SeeEnemy(other.gameObject);
            Debug.Log("ontriggstay");
        }
    }*/

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            SeeEnemy(other.gameObject);
            //Debug.Log("ontriggstay");
        }
    }
}
