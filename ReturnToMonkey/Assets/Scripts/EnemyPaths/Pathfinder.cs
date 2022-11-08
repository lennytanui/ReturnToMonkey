using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    public EnemyPathFinding path;
    public EnemyStats stats;
    public float delayBeforeMove;
    public bool isRand;

    List<Transform> waypoints;
    private int waypointIndex = 0;
    public Vector3 targetPosition = new Vector3(0,0,0);
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = path.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            if (canMove)
            {
                targetPosition = waypoints[waypointIndex].position;
                float delta = stats.speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
                if (transform.position == targetPosition)
                {
                    if (isRand) {
                        waypointIndex = UnityEngine.Random.Range(0, waypoints.Count);
                    } else
                    {
                        waypointIndex++;
                    }
                    StartCoroutine(StartDelay(delayBeforeMove));
                }
            }
            
        }
        else
        {
            waypointIndex = 0;
        }
    }

    IEnumerator StartDelay(float delay)
    {
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
