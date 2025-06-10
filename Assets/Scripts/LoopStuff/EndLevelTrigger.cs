using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class EndLevelTrigger : MonoBehaviour
{
    public Image black;
    public Animator anim;

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DiaryCS");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fading());
            //SceneManager.LoadScene("DiaryCS"); 
        }
    }


}
