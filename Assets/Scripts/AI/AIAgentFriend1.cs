using System;
using UnityEngine;
using Pathfinding;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AIAgentFriend1 : MonoBehaviour
{
    private AIPath aiPath;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;
    private float distanceToTarget;

    [SerializeField] private float stoppingDistanceThreshold;
    [SerializeField] private float chasingDistance;

    private float patrolRadius = 2f;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        animator.SetBool("Idle",true);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void UpdatePath()
    {
        aiPath.maxSpeed = moveSpeed;
        //Move to target position
        //aiPath.destination = target.position;
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > chasingDistance)
        {
            //Chase when the player is far
            Vector2 randomOffset = Random.insideUnitCircle * patrolRadius;
            aiPath.destination =  randomOffset;
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Walk",true);
            //aiPath.destination = transform.position;

            //Chase when player is near
            // aiPath.destination = target.position;
        }
        else if(distanceToTarget < chasingDistance && distanceToTarget <= stoppingDistanceThreshold)
        {
            //Chase when the player is far
            aiPath.destination = transform.position;
             
            animator.SetBool("Idle", true);
            animator.SetBool("Walk",false);
            animator.SetBool("Attack", false);
           

            //Chase when player is near
            // aiPath.destination=transform.position;
        }
        else
        {
            aiPath.destination = target.position;
            animator.SetBool("Idle", false);
            animator.SetBool("Walk",true);
            animator.SetBool("Attack", false);
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     animator.SetBool("Idle", false);
        //     animator.SetBool("Walk",false);
        //     animator.SetBool("Attack", true);
        // }
    }
}