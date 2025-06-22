using System.Collections;
using UnityEngine;
using Convai.Scripts.Runtime.Core;  // Make sure this matches your Convai SDK

public class NPCQuarrelTrigger : MonoBehaviour
{
    public ConvaiNPC professorLiang;
    public ConvaiNPC meiLin;

    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            hasPlayed = true;
            StartCoroutine(PlayQuarrelScene());
        }
    }

    IEnumerator PlayQuarrelScene()
    {
        professorLiang.SendTextDataAsync("<speak>Mei Lin. I didn’t expect to see you here again.</speak>");
        yield return new WaitForSeconds(3.5f);

        meiLin.SendTextDataAsync("<speak>So this is where you stand now… behind your podium, like nothing happened.</speak>");
        yield return new WaitForSeconds(3.5f);

        professorLiang.SendTextDataAsync("<speak>You don’t understand… I had to make a choice. My future depended on it.</speak>");
        yield return new WaitForSeconds(4f);

        meiLin.SendTextDataAsync("<speak>And what about my future? Our child? You said you loved me… was that all just a lie?</speak>");
        yield return new WaitForSeconds(3f);
		
		professorLiang.SendTextDataAsync("<speak>It wasn’t a lie! But I couldn’t risk everything over a… mistake.</speak>");
        yield return new WaitForSeconds(3.5f);
		
		meiLin.SendTextDataAsync("<speak>A mistake? I was never your mistake. You were afraid. Afraid to face the truth — so you pushed me.</speak>");
        yield return new WaitForSeconds(4f);
		
		professorLiang.SendTextDataAsync("<speak>I—I didn’t mean to. You were hysterical… I lost control… it was an accident.</speak>");
        yield return new WaitForSeconds(3.5f);
		
		meiLin.SendTextDataAsync("<speak>Then why did you run? Why did you burn my diary? Leave my body… my voice… buried?</speak>");
        yield return new WaitForSeconds(3.5f);
		
		professorLiang.SendTextDataAsync("<speak>I thought if no one knew… it would all go away. That I could forget. That… maybe you would forgive me.</speak>");
        yield return new WaitForSeconds(4f);
		
		meiLin.SendTextDataAsync("<speak>Forgive you? I begged for the truth to be told. And now I'm trapped here… reliving this pain… because of your silence.</speak>");
        yield return new WaitForSeconds(4f);
		
		professorLiang.SendTextDataAsync("<speak>I… I never wanted this.</speak>");
        yield return new WaitForSeconds(3f);
		
		meiLin.SendTextDataAsync("<speak>Then stop hiding. Tell the truth. Let me go.</speak>");
        yield return new WaitForSeconds(3f);

        // (Continue the rest of the script as needed)
    }
}
