using UnityEngine;
using System.Collections;

public class TutorialSetting : MonoBehaviour {
    [SerializeField]
    private bool startWithTutorial;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public bool StartWithTutorial {
        get { return startWithTutorial; }
        set { startWithTutorial = value; }
    }
}
