using UnityEngine;
using System.Collections;

public class Despawn : Timer {


    public override void TimerOver()
    {
        base.TimerOver();
        Destroy(this.gameObject);
    }
}
