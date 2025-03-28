using UnityEngine;
using Pathfinding;

public class AIAgentFleeNear : MonoBehaviour
{
    private AIPath aiPath;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;
    private float distanceToTarget;

    [SerializeField] private float stoppingDistanceThreshold;
    private float patrolRadius = 3f;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("UpdatePath", 0f, 0.1f);
    }

    private void UpdatePath()
    {
        aiPath.maxSpeed = moveSpeed;
        //Move to target position
        //aiPath.destination = target.position;
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > stoppingDistanceThreshold)
        {
            //Chase when the player is far
           // Vector2 randomOffset = Random.insideUnitCircle * patrolRadius;
            aiPath.destination =transform.position;
            
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
           
            //Chase when player is near
            // aiPath.destination = target.position;
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
            var destination = (transform.position - target.position);
            //Chase when the player is far
            aiPath.destination = destination;

            //Chase when player is near
            // aiPath.destination=transform.position;
        }
        
    }
}