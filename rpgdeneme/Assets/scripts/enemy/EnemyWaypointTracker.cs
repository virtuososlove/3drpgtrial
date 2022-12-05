using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaypointTracker : MonoBehaviour
{
    public Transform[] walkpoints;
    [Header("movement settings")]
    public float turnspeed = 5f;
    public float patroltime = 10f;
    public float walkdistance = 8f;
    [Header("Attack Settings")]
    public float attackdistance = 1.4f;
    public float attackrate = 1f;

    private Transform playertransform;
    private Animator animator;
    private NavMeshAgent agent;
    private float currentattacktime = 0f;
    private Vector3 nextdestination;
    int index;

    private void Awake()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        index = Random.Range(0, walkpoints.Length);
        InvokeRepeating("setpatrol", 10f, patroltime);
    }
    void Start()
    {
        agent.avoidancePriority = Random.Range(1, 51);
    }
    void Update()
    {
        
        moveandattack();
    }
    private void moveandattack()
    {
        float distance = Vector3.Distance(transform.position, playertransform.position);
        if(distance >= walkdistance || playertransform.gameObject.GetComponent<playerhealth>().currenthealth < 0)
        {
            if(agent.remainingDistance >= agent.stoppingDistance)
            {
                agent.isStopped = false;
                agent.speed = 2f;
                animator.SetBool("Walk", true);
                nextdestination = walkpoints[index].position;
                agent.SetDestination(nextdestination);
            }
            else
            {
                agent.isStopped = true;
                agent.speed = 0f;
                animator.SetBool("Walk", false);
                nextdestination = walkpoints[index].position;
                agent.SetDestination(nextdestination);
            }
        }
        else
        {
            if(playertransform.gameObject.GetComponent<playerhealth>().currenthealth < 0)
            {

                animator.ResetTrigger("Attack");
                agent.isStopped = false;
                agent.speed = 3f;
                animator.SetBool("Walk", true);
                agent.SetDestination(nextdestination);
            }
            else if(distance >= attackdistance + 0.15f)
            {
                if(!animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                    animator.ResetTrigger("Attack");
                    agent.isStopped = false;
                    agent.speed = 3f;
                    animator.SetBool("Walk", true);
                    agent.SetDestination(playertransform.position);
                }
            }
            else if(distance <= attackdistance && playertransform.gameObject.GetComponent<playerhealth>().currenthealth > 0)
            {
                agent.isStopped = true;
                agent.speed = 0f;
                animator.SetBool("Walk", false);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playertransform.position - transform.position),Time.deltaTime * turnspeed);
                if (currentattacktime >= attackrate)
                {
                    animator.SetTrigger("Attack");
                    currentattacktime = 0f;
                }
                else
                {
                    currentattacktime += Time.deltaTime;
                }
            }
        }
        
    }
    private void setpatrol()
    {
        if(index >= walkpoints.Length - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
    }
}
