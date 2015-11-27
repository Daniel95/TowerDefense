using UnityEngine;

public class SetTutorialSetting : MonoBehaviour {

    private TutorialSetting tutorial;

    private bool showTutorial;

    void Awake() {
        tutorial = GameObject.Find("Tutorial Setting").GetComponent<TutorialSetting>();
    }

    public void ChangeTutorialSetting() {
        showTutorial = !showTutorial;
        tutorial.StartWithTutorial = showTutorial;
    }
}
