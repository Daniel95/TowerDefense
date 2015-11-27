using UnityEngine;

public class GetTutorialSetting : MonoBehaviour {

    void Awake() {
        if (GameObject.Find("Tutorial Setting") != null)
        {
            bool showTutorial = GameObject.Find("Tutorial Setting").GetComponent<TutorialSetting>().StartWithTutorial;
            GetComponent<ToggleGameobjectActive>().ToggleFromScript(showTutorial);
        } else GetComponent<ToggleGameobjectActive>().ToggleFromScript(false);
    }
}
