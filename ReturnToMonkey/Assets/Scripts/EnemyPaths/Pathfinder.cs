using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    public EnemyPathFinding path;
    public EnemyStats stats;

    List<Transform> waypoints;
    public int waypointIndex = 0;
    public Vector3 targetPosition = new Vector3(0,0,0);

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
            targetPosition = waypoints[waypointIndex].position;
            float delta = stats.speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    }
}
