using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform target; //이동 목표
    NavMeshAgent agent; //ai
    Animator anim;

    enum State
    {
        Idle,
        Run,
        Attack
    }
    State state;

    void Start()
    {
        state = State.Idle;
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    float targetToDis;
    void Update()
    {
        targetToDis = Vector3.Distance(transform.position, target.transform.position);
        //Bar -= Time.DeltaTime;

        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Run)
        {
            UpdateRun();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
    }

    private void UpdateAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Destroy(this.gameObject);

        agent.speed = 0;
        if (targetToDis > 2)
        {
            state = State.Run;
            anim.SetTrigger("Run");
        }
    }

    private void UpdateRun() 
    {
        agent.speed = 3.5f;
        agent.destination = target.transform.position; //목표 지점
        
        if (targetToDis <= 2)
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }
        else if (targetToDis > 15)
        {
            state = State.Idle;
            anim.SetTrigger("Idle");
        }
    }

    private void UpdateIdle()
    {
        agent.speed = 0;

        if (targetToDis < 15)
        {
            state = State.Run;
            anim.SetTrigger("Run");
        }
    }
}