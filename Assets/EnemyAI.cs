/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    private enum State
    {
        Roaming,
        ChaseTarget,
        ShootingTarget,
        GoingBackToStart,
    }

    public AIPath aiPath;
    private Vector3 startingPosition;
    private float nextShootTime;
    private State state;
    private GameObject player;
    private AIDestinationSetter aiDestinationSetter;
    private GameObject fabricatedDestination;
    [SerializeField]
    private Vector2 patrolRange = new Vector2(10f, 6f);
    [SerializeField]
    private float visionRange = 12f;
    [SerializeField]
    private float stopChaseDistance = 15f;
    [SerializeField]
    private float attackRange = 10f;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        state = State.Roaming;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        startingPosition = transform.position;
        fabricatedDestination = new GameObject();
        fabricatedDestination.transform.position = GetRoamingPosition();
        aiDestinationSetter.target = fabricatedDestination.transform;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                if (aiPath.reachedDestination)
                {
                    Debug.Log("Reached patrol path, getting new patrol spot");
                    fabricatedDestination.transform.position = GetRoamingPosition();
                }

                FindTarget();
                break;
            case State.ChaseTarget:
                if (Vector3.Distance(transform.position, player.transform.position) > stopChaseDistance)
                {
                    Debug.Log("Player out of chase range, going back to start");
                    state = State.GoingBackToStart;
                }

                if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
                {
                    state = State.ShootingTarget;
                }
                break;
            case State.ShootingTarget:
                if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
                {
                    Debug.Log("Player in range, firing");
                    GetComponent<ProjectileController>().FireAtPlayer();
                } else
                {
                    state = State.ChaseTarget;
                }
                break;
            case State.GoingBackToStart:
                fabricatedDestination.transform.position = startingPosition;
                aiDestinationSetter.target = fabricatedDestination.transform;
                state = State.Roaming;
                break;
        }
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + new Vector3(Random.Range(-patrolRange.x, patrolRange.x), Random.Range(-patrolRange.y, patrolRange.y), 1);
    }

    private void FindTarget()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < visionRange)
        {
            Debug.Log("Found player target");
            // Player within target range
            state = State.ChaseTarget;
            aiDestinationSetter.target = player.transform;
        }
    }

}
