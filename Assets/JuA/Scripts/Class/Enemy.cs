using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform target; //이동 목표
    NavMeshAgent agent; //ai
    Animator anim;

    public float curHp = 100;
    public float maxHp = 100;
    public float damage = 20;

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

        transform.GetChild(0).TryGetComponent(out anim);
        JongChan.GameManager.Instance.Enemies.Add(this);
        JongChan.GameManager.Instance.FixAction += ShipDamage;
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
        
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void UpdateAttack()
    {
        if (curHp <= 0)
        {
            Destroy(gameObject);
            JongChan.GameManager.Instance.Gold += 20;
        }

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

    private void OnDisable()
    {
        JongChan.GameManager.Instance.Enemies.Remove(this);
        JongChan.GameManager.Instance.FixAction -= ShipDamage;
    }
    
    private void ShipDamage(float damage)
    {
        JongChan.GameManager.Instance.ShipCurHp -= Time.deltaTime * 5;
    }
}