using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour {

    [SerializeField]
    private Sprite[] gameSpeedSprites;

    private Image image;

    private int gameSpeed = 1;

    void Awake() {
        image = GetComponent<Image>();
    }

    public void NewGameSpeed()
    {
        if (gameSpeed == 0)
        {
            image.sprite = gameSpeedSprites[gameSpeed];
            Time.timeScale = 1;
            gameSpeed++;
        }
        else if (gameSpeed == 1)
        {
            image.sprite = gameSpeedSprites[gameSpeed];
            Time.timeScale = 2;
            gameSpeed++;
        }
        else if (gameSpeed == 2)
        {
            image.sprite = gameSpeedSprites[gameSpeed];
            Time.timeScale = 3;
            gameSpeed = 0;
        }
    }

    public int GetGameSpeed {
        get { return gameSpeed; }
    }
}
