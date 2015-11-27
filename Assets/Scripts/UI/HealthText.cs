using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    private Text healthText;

    private void Awake() {
        healthText = GetComponent<Text>();
    }

    public void SetText(float _lives) {
        _lives = (int)_lives;
        healthText.text = _lives.ToString();
    }
}
