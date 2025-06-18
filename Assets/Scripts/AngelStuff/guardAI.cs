using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Animator aiAnim;

    public Transform dest1, dest2;
    private Transform currentTarget;

    public float idleTime;
    private bool isWalking = true;
    private bool isIdle = false;

    void Start()
    {
        // Randomly pick starting destination
        currentTarget = Random.Range(0, 2) == 0 ? dest1 : dest2;
        MoveToDestination();
    }

    void Update()
    {
        if (isWalking && !ai.pathPending && ai.remainingDistance <= ai.stoppingDistance)
        {
            StartCoroutine(IdleAndSwitch());
        }
    }

    void MoveToDestination()
    {
        aiAnim.SetTrigger("walk");
        aiAnim.ResetTrigger("idle");
        ai.SetDestination(currentTarget.position);
        ai.speed = 3;
        isWalking = true;
        isIdle = false;
    }

    IEnumerator IdleAndSwitch()
    {
        if (isIdle) yield break; // Prevent multiple coroutines
        isIdle = true;
        isWalking = false;
        aiAnim.SetTrigger("idle");
        aiAnim.ResetTrigger("walk");
        ai.speed = 0;

        yield return new WaitForSeconds(idleTime);

        // Switch to the other destination
        currentTarget = (currentTarget == dest1) ? dest2 : dest1;
        MoveToDestination();
    }
}