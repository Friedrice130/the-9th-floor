using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAutoLoadScene : MonoBehaviour
{
    public string sceneName = "GameScene_VR";  // The scene you want to load
    public float delay = 22f;                  // Delay in seconds

    void Start()
    {
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
