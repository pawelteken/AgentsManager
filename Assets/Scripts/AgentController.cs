using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    [SerializeField] internal float moveSpeed = 2f;

    internal AgentsManager agentsManager;
    internal Vector3 destination;
    internal Transform tr;

    public virtual void Awake()
    {
        tr = transform;
    }

    public virtual void OnDestroy()
    {
        tr.DOKill();
    }

    public void Init(AgentsManager setAgentsManager)
    {
        agentsManager = setAgentsManager;
    }

    public virtual void MoveToNewDestination()
    {
        destination = agentsManager.GetRandomPoint();
        tr.LookAt(destination);
        float duration = Vector3.Distance(tr.position, destination) / moveSpeed;
        
        tr.DOMove(destination, duration)
            .SetEase(Ease.Linear)
            .onComplete = DestinationReached;
    }

    internal void DestinationReached()
    {
        MoveToNewDestination();
    }
}