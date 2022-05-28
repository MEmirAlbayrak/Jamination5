using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    private NavMeshAgent agent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = player.transform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
        agent.SetDestination(driftPos);
    }
}
