using UnityEngine;
using System.Collections;

public class GameSpeed : MonoBehaviour {

    private int gameSpeed = 1;

    public void NewGameSpeed()
    {
        if (gameSpeed == 1)
        {
            Time.timeScale = gameSpeed;
            gameSpeed++;
        }
        else if (gameSpeed == 2)
        {
            Time.timeScale = gameSpeed;
            gameSpeed++;
        }
        else if (gameSpeed == 3)
        {
            Time.timeScale = gameSpeed;
            gameSpeed = 0;
        }
    }

    public int GetGameSpeed {
        get { return gameSpeed; }
    }
}
