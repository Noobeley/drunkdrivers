using UnityEngine;
using UnityEngine.AI;

public class NPCPath : MonoBehaviour
{
    public Transform[] path1Waypoints; // Waypoints for Path 1
    public Transform[] path2Waypoints; // Waypoints for Path 2
    public Transform[] path3Waypoints; // Waypoints for Path 3
    public Transform branchPoint;      // Branch point location

    private NavMeshAgent agent;
    private int currentWaypoint = 0;
    private bool pathSelected = false; // Set true when a path is chosen
    private Transform[] currentPathWaypoints; // The currently selected path waypoints

    private bool isPathComplete = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void StartInitialPath()
    {
        // Set the NPC to start on Path 1
        currentPathWaypoints = path1Waypoints;
        currentWaypoint = 0;
        agent.SetDestination(currentPathWaypoints[currentWaypoint].position);
    }

    void Update()
    {
        // Stop at the branch point and wait for path selection
        if (!pathSelected && Vector3.Distance(transform.position, branchPoint.position) < 1f)
        {
            agent.isStopped = true; // Pause at the branch point
        }
        else if (pathSelected && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextWaypoint();
        }
    }

    // Called when the player selects a path at the branch point
    public void SetPath(int pathNumber)
    {
        if (pathNumber == 2)
        {
            currentPathWaypoints = path2Waypoints;
        }
        else if (pathNumber == 3)
        {
            currentPathWaypoints = path3Waypoints;
        }

        // Reset the path progress and resume movement
        currentWaypoint = 0;
        pathSelected = true;
        isPathComplete = false;
        agent.isStopped = false;
        agent.SetDestination(currentPathWaypoints[currentWaypoint].position);
    }

    private void MoveToNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint < currentPathWaypoints.Length)
        {
            agent.SetDestination(currentPathWaypoints[currentWaypoint].position);
        }
        else
        {
            // Path is complete when the final waypoint on Path 2 or Path 3 is reached
            isPathComplete = pathSelected;
            agent.isStopped = true;
        }
    }

    public bool IsPathCompleted()
    {
        // Return true if either Path 2 or Path 3 has completed
        return isPathComplete;
    }
}

    