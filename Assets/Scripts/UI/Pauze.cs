using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    private bool paused = false;

    private GameSpeed gameSpeed;

    private SlideMenu slideMenu;

    private GameObject backToMenu;

    void Awake() {
        gameSpeed = GameObject.Find("Game Speed").GetComponent<GameSpeed>();
        slideMenu = GameObject.Find("Select New Tower").GetComponent<SlideMenu>();
        backToMenu = GameObject.Find("Back To Menu").gameObject;
        backToMenu.SetActive(false);
    }

    public void PauseGame()
    {

        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            slideMenu.InstantVisible(true);
            backToMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = gameSpeed.GetGameSpeed;
            paused = false;
            slideMenu.InstantVisible(false);
            backToMenu.SetActive(false);
        }
    }
}
