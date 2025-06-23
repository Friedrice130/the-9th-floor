using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroAutoLoadScene : MonoBehaviour
{
    public string sceneName = "MainMenu_VR";  // The scene you want to load
    public float delay = 51f;                  // Delay in seconds

    void Start()
    {
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
