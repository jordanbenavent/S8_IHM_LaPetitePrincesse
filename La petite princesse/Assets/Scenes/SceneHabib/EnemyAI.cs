using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private Transform priorityTarget=null;
    public Transform AI;
    public List<Checkpoint> checkpoints;
    public UnityEngine.AI.NavMeshAgent agent;
    private int currentDestination=0; 
    private float oldTime;
    private float oldTimeAttacking;
    private bool isAttacking = false;
    public Animator animator;
    public Collider collider;
    private bool isOnRange=false;

    void Start()
    { 
        agent= gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = checkpoints[currentDestination].transform;
        oldTime = Time.time;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            priorityTarget = collider.transform;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            priorityTarget = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isOnRange);
        if (priorityTarget != null)
        {
            isOnRange = true;

            if(Mathf.Abs(AI.position.x - priorityTarget.position.x) < 2.1f & Mathf.Abs(AI.position.z - priorityTarget.position.z) < 2.1f)
            {

                animator.SetFloat("isAttackingTime", Time.time - oldTimeAttacking);
                if (Time.time - oldTimeAttacking > 4 & isAttacking == true)
                {
                    animator.SetBool("isAttacking", false);
                    isAttacking = false;
                    transform.LookAt(priorityTarget);


                }
                if (isAttacking == false)
                {
                    animator.SetFloat("isAttackingTime", 4);
                    Debug.Log("J'attaque");
                    agent.destination = AI.position;
                    transform.LookAt(priorityTarget);
                    animator.Play("attack");
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isMoving", false);
                    isAttacking = true;
                    oldTimeAttacking = Time.time;
                }
            }

            else
            {
                agent.destination = priorityTarget.position;
                animator.SetBool("isMoving", true);
               
            }

        }

        else
        {
            isAttacking=false;  
            if (isOnRange == true)
            {
                isOnRange = false;
                agent.destination = target.position;
            }

            if (Time.time - oldTime > 3)
            {
                agent.destination = target.position;
                animator.SetBool("isMoving", true);
            }

            if (Mathf.Abs(AI.position.x - target.position.x) < 0.3f & Mathf.Abs(AI.position.z - target.position.z) < 0.3f)
            {
                currentDestination = (currentDestination + 1) % checkpoints.Count;
                target = checkpoints[currentDestination].transform;
                oldTime = Time.time;
                animator.SetBool("isMoving", false);
            }
        }
    }
}
