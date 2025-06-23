using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class NextButtonController : MonoBehaviour
{
    public Button nextButton;  // Assign your button in the inspector
    public float delayTime = 21f;

    void Start()
    {
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);  // Hide button initially
            StartCoroutine(ShowButtonAfterDelay());
            nextButton.onClick.AddListener(LoadGameScene);
        }
        else
        {
            Debug.LogWarning("NextButtonController: No button assigned!");
        }
    }

    IEnumerator ShowButtonAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        nextButton.gameObject.SetActive(true);
        nextButton.interactable = true;  // Ensure it can be clicked
    }


    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene_VR");
    }
}
