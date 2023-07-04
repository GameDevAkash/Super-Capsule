using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsFollower : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] int currentPoint;
    [SerializeField] float speed;
    [SerializeField] float tes;

    void Update()
    {
        tes = Vector3.Distance(transform.position, wayPoints[currentPoint].transform.position);
        if (Vector3.Distance(transform.position, wayPoints[currentPoint].transform.position) <= .1f)
        {
            currentPoint++;
            if(currentPoint>=wayPoints.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPoint].transform.position, speed*Time.deltaTime);
            
    }
}
