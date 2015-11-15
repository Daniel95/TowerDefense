using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public void LoadAScene(string scene)
    {
        Application.LoadLevel(scene);
    }

}
