using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class MainMenuButtons : MonoBehaviour
{
    public Image black;
    public Animator anim;

    public void startButton()
    {
        StartCoroutine(Fading()); 
        //SceneManager.LoadScene("IntroCS"); 
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        SceneManager.LoadScene("IntroCS");
        yield return new WaitForSeconds(3f); // Adjust based on your fade animation length
        
    }

    public void quitButton()
    { UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
