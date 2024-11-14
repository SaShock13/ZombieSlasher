using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public enum EnemyBehState
{
    Idle,
    Steering,
    Attack,
    Wandering,
    Death
}

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    private Animator animator;
    private NavMeshAgent agent;
    public bool isAlive = true;
    public bool isMovable = false;

    public float remDist;


    public EnemyBehState state = EnemyBehState.Idle;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform endTransform;
    private Transform currentDestination;
    private EnemyStateHandler stateHandler;

    [SerializeField] private GameObject enemyModelPrefab;

    private void Awake()
    {
        Instantiate<GameObject>(enemyModelPrefab, transform);
        playerTransform = FindObjectOfType<Player>().transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        currentDestination = endTransform;
        stateHandler = GetComponent<EnemyStateHandler>();
    }

    public void ChangeOnSteering()
    {
        state = EnemyBehState.Steering;
    }
    public void ChangeOnWandering()
    {
        state = EnemyBehState.Wandering;
    }
    public void ChangeOnAttack()
    {
        state = EnemyBehState.Attack;
    }
    public void ChangeOnIdle()
    {
        state = EnemyBehState.Idle;
    }
    public void ChangeOnDeath()
    {
        state = EnemyBehState.Death;
    }



    private void Update()
    {
        if (isAlive)
        {
            switch (state)
            {
                case EnemyBehState.Idle:
                    {
                        animator.SetTrigger("Idle");
                        break;
                    }
                case EnemyBehState.Wandering:
                    {
                        animator.SetTrigger("Walk");
                        agent.destination = currentDestination.position;
                        stateHandler.StartCheck();

                        remDist = agent.remainingDistance;

                        if (agent.remainingDistance !=0 & agent.remainingDistance <= 0.8f & agent.remainingDistance!=float.PositiveInfinity & agent.remainingDistance!= float.NegativeInfinity)
                        {
                            currentDestination = currentDestination == endTransform ? startTransform : endTransform;
                            agent.destination = currentDestination.position;
                        }
                        break;
                    }
                case EnemyBehState.Steering:
                    {
                        animator.SetTrigger("Walk");
                        agent.destination = playerTransform.position;
                        if (agent.remainingDistance <= agent.stoppingDistance + 0.02f)
                        {
                            state = EnemyBehState.Attack;
                        }
                        break;
                    }
                case EnemyBehState.Attack:
                    {
                        animator.SetTrigger("Attack");
                        if (agent.remainingDistance > agent.stoppingDistance + 0.02f)
                        {
                            state = EnemyBehState.Steering;
                        }
                        //state = EnemyBehState.Steering;
                        break;
                    }

                case EnemyBehState.Death:
                    {
                        animator.SetTrigger("Death");
                        isAlive = false;
                        break;
                    }
                default: break;
            }

        }
        else agent.isStopped =true;

        //else animator.SetBool("Attacking", false);
    }
}
