using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    public string SceneName;
    public float waitTime;

    void Start()
    {
        StartCoroutine(loadToL9());
    }
    IEnumerator loadToL9()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneName);
    }
}
