using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    
    AgentsManager agentsManager;
    Vector3 destination;
    Transform tr;

    void Awake()
    {
        tr = transform;
    } 

    public void Init(AgentsManager setAgentsManager)
    {
        agentsManager = setAgentsManager;
    }
    
    public void MoveToNewDestination()
    {
        destination = agentsManager.GetRandomPoint();
        tr.LookAt(destination);
        float duration = Vector3.Distance(tr.position, destination) / moveSpeed;
        tr.DOMove(destination, duration).onComplete = DestinationReached;
    }

    void DestinationReached()
    {
        MoveToNewDestination();
    }
}
