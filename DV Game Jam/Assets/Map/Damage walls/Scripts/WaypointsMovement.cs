using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed;
    //private Vector2 curWaypointPosition;
    // Start is called before the first frame update
    void Start()
    {
        //curWaypointPosition = waypoints[currentWaypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(/*curWaypointPosition*/ waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, /*curWaypointPosition*/ waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
