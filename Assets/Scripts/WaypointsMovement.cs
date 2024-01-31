using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int index = 0;

    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[index].transform.position, transform.position) < 0.1f)
        {
            index++;
            index %= waypoints.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
    }
}
