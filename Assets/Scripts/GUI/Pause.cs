using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    private bool paused = false;

    public void PauseGame() {

        if (!paused) {
            Time.timeScale = 0;
            paused = true;
            Debug.Log("pause");
        } else {
            Time.timeScale = 1;
            paused = false;
        }
    }
}
