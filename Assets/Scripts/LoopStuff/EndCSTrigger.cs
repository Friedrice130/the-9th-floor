using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCSTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            SceneFader.Instance.FadeToNextScene();
            // SceneManager.LoadScene("EndCS");s
        }
    }
}
