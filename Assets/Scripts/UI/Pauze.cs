using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    private bool paused = false;

    private GameSpeed gameSpeed;

    void Awake() {
        gameSpeed = GameObject.Find("Game Speed").GetComponent<GameSpeed>();
    }

    public void PauseGame()
    {

        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            Time.timeScale = gameSpeed.GetGameSpeed;
            paused = false;
        }
    }
}
