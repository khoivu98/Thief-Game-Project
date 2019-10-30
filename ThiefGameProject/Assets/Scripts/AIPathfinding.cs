using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPathfinding : MonoBehaviour {

    NavMeshAgent agent;

    //Waypoints to patrol
    public List<Vector3> waypoints;
    int curWaypoint = -1;

    public enum State {PATROL, CHASE, TRACK};
    State state;

    public ThirdPersonCharacterController Liam;

    //Target to chase
    public GameObject player;

    //Last position of the player
    Vector3 lastPlayerPosition;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        state = State.PATROL; //Initially, the enemy will patrol
	}
	
	// Update is called once per frame
	void Update () {
        
        switch (state)
        {
            case State.PATROL:
                {
                    GetComponent<Renderer>().material.color = Color.green;

                    Vector3 dir = player.transform.position - this.transform.position;
                    RaycastHit hit;

                    if(Physics.Raycast(this.transform.position, dir, out hit))
                    {
                        
                        Debug.Log(hit.collider.gameObject.name);
                        Debug.DrawLine(transform.position, hit.collider.gameObject.transform.position, Color.green);
                        if (hit.collider.gameObject == player && !Liam.isSeen &&!Liam.isHiding)
                        {
                            Liam.isSeen = true;
                            state = State.CHASE;
                            agent.SetDestination(player.transform.position);
                            lastPlayerPosition = player.transform.position;
                            break;
                        }
                    }

                    float disToWaypoint = agent.remainingDistance;
                    if(Mathf.Approximately(disToWaypoint, 0))
                    {
                        agent.SetDestination(GetNextWaypoint());
                    }
                   
                }
                break;
            case State.CHASE:
                {
                    GetComponent<Renderer>().material.color = Color.red;
                    Debug.DrawLine(transform.position, player.transform.position, Color.red);

                    Vector3 dir = player.transform.position - this.transform.position;

                    RaycastHit hit;

                    if (Physics.Raycast(this.transform.position, dir, out hit))
                    {
                        if(hit.collider.gameObject == player && Liam.isSeen && !Liam.isHiding)
                        {
                            agent.SetDestination(player.transform.position);
                            lastPlayerPosition = player.transform.position;
                            break;
                        }
                    }

                    state = State.TRACK;
                    Liam.isSeen = false;
                    agent.SetDestination(lastPlayerPosition);
                }
                break;
            case State.TRACK:
                {
                    GetComponent<Renderer>().material.color = Color.yellow;
                    Debug.DrawLine(transform.position, lastPlayerPosition, Color.yellow);

                    Vector3 dir = player.transform.position - this.transform.position;

                    RaycastHit hit;

                    if(Physics.Raycast(this.transform.position, dir, out hit))
                    {
                        if(hit.collider.gameObject == player && !Liam.isHiding)
                        {
                            Liam.isSeen = true;
                            state = State.CHASE;
                            break;
                        }
                    }
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        state = State.PATROL;
                    }   
                }
                break;
        }

	}

    Vector3 GetNextWaypoint()
    {
        curWaypoint++;
        if(curWaypoint  == waypoints.Count)//When reached the last waypoint
        {
            curWaypoint = 0;//Go back to the initial waypoint
        }
        return waypoints[curWaypoint];
    }

}
