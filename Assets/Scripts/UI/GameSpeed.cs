using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour {

    [SerializeField]
    private Sprite[] gameSpeedSprites;

    private SlideMenu slideMenu;

    private GameObject backToMenu;

    private Image image;

    private int gameSpeed = 0;

    void Awake() {
        image = GetComponent<Image>();

        slideMenu = GameObject.Find("Select New Tower").GetComponent<SlideMenu>();
        backToMenu = GameObject.Find("Back To Menu").gameObject;
        backToMenu.SetActive(false);

        NewGameSpeed();
    }

    public void NewGameSpeed()
    {
        gameSpeed++;
        if (gameSpeed == 0)
        {
            image.sprite = gameSpeedSprites[0];
            backToMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (gameSpeed == 1)
        {
            image.sprite = gameSpeedSprites[1];
            backToMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else if (gameSpeed == 2)
        {
            image.sprite = gameSpeedSprites[2];
            Time.timeScale = 2.5f;
        }
        else if (gameSpeed == 3)
        {
            image.sprite = gameSpeedSprites[3];
            Time.timeScale = 6;
            gameSpeed = -1;
        }
    }

    public int GetGameSpeed {
        get { return gameSpeed; }
    }
}
