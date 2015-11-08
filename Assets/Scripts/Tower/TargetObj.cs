using UnityEngine;
using System.Collections;

public class TargetObj : MonoBehaviour {

    public virtual void DetectEnemy(GameObject _enemy)
    {

    }

    public virtual void LoseEnemy(GameObject _enemy)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            DetectEnemy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            LoseEnemy(other.gameObject);
        }
    }
}
