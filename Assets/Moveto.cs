using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Moveto : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}