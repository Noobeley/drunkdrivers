using UnityEngine;
using UnityEngine.AI;

public class NPCPath : MonoBehaviour
{
    public Transform[] path1Waypoints;  // Waypoints for the first path
    public Transform[] path2Waypoints;  // Waypoints for the second path
    public Transform branchPoint;       // The branching point where the player decides

    private NavMeshAgent agent;
    private int currentWaypoint = 0;
    private bool isFollowingPath1 = true;
    private bool branchChosen = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Start moving towards the first waypoint of the main path
        agent.SetDestination(path1Waypoints[currentWaypoint].position);
    }

    void Update()
    {
        // Move NPC along the chosen path
        if (!branchChosen && Vector3.Distance(transform.position, branchPoint.position) < 1f)
        {
            // When NPC reaches the branch point, player must decide the path
            PlayerChoosePath();
        }

        if (branchChosen)
        {
            // Check if NPC has reached the current waypoint
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                MoveToNextWaypoint();
            }
        }
    }

    void PlayerChoosePath()
    {
        // This is where you take player input to choose the path (e.g. through VR controller buttons)
        // For example, if player presses button A, follow path1, if button B, follow path2.
        if (Input.GetKeyDown(KeyCode.O))  // Replace with VR input system as needed
        {
            isFollowingPath1 = true;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path1Waypoints[currentWaypoint].position);
        }
        else if (Input.GetKeyDown(KeyCode.P))  // Replace with VR input system as needed
        {
            isFollowingPath1 = false;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path2Waypoints[currentWaypoint].position);
        }
    }

    void MoveToNextWaypoint()
    {
        // Update current waypoint and set the NPC's destination to the next one
        currentWaypoint++;

        if (isFollowingPath1)
        {
            if (currentWaypoint < path1Waypoints.Length)
            {
                agent.SetDestination(path1Waypoints[currentWaypoint].position);
            }
            else
            {
                // Path complete, you can stop the NPC or trigger an event
                agent.isStopped = true;
            }
        }
        else
        {
            if (currentWaypoint < path2Waypoints.Length)
            {
                agent.SetDestination(path2Waypoints[currentWaypoint].position);
            }
            else
            {
                // Path complete, you can stop the NPC or trigger an event
                agent.isStopped = true;
            }
        }
    }
}
