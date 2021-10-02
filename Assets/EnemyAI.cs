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

    //private EnemyPathfindingMovement pathfindingMovement;
    public AIPath aiPath;
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private float nextShootTime;
    private State state;
    private GameObject player;

    private void Awake()
    {
        //pathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        state = State.Roaming;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        //switch (state)
        //{
        //    default:
        //    case State.Roaming:
        //        pathfindingMovement.MoveToTimer(roamPosition);

        //        float reachedPositionDistance = 10f;
        //        if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
        //        {
        //            // Reached Roam Position
        //            roamPosition = GetRoamingPosition();
        //        }

        //        FindTarget();
        //        break;
        //    case State.ChaseTarget:
        //        pathfindingMovement.MoveToTimer(player.transform.position);

        //        float attackRange = 30f;
        //        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        //        {
        //            // Target within attack range
        //            if (Time.time > nextShootTime)
        //            {
        //                pathfindingMovement.StopMoving();
        //                state = State.ShootingTarget;
        //                float fireRate = .15f;
        //                nextShootTime = Time.time + fireRate;
        //            }
        //        }

        //        float stopChaseDistance = 80f;
        //        if (Vector3.Distance(transform.position, player.transform.position) > stopChaseDistance)
        //        {
        //            // Too far, stop chasing
        //            state = State.GoingBackToStart;
        //        }
        //        break;
        //    case State.ShootingTarget:
        //        break;
        //    case State.GoingBackToStart:
        //        pathfindingMovement.MoveToTimer(startingPosition);

        //        reachedPositionDistance = 10f;
        //        if (Vector3.Distance(transform.position, startingPosition) < reachedPositionDistance)
        //        {
        //            // Reached Start Position
        //            state = State.Roaming;
        //        }
        //        break;
        //}
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition * Random.Range(10f, 70f);
    }

    private void FindTarget()
    {
        float targetRange = 50f;
        if (Vector3.Distance(transform.position, player.transform.position) < targetRange)
        {
            // Player within target range
            state = State.ChaseTarget;
        }
    }

}
