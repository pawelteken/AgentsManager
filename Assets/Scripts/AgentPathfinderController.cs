using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Pathfinding;
using UnityEngine;

public class AgentPathfinderController : AgentController
{
    Seeker seeker;

    override public void Awake()
    {
        base.Awake();
        seeker = GetComponent<Seeker>();
    }

    public override void MoveToNewDestination()
    {
        destination = agentsManager.GetRandomPoint();
        seeker.StartPath(tr.position, destination, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error)
        {
            MoveToNewDestination();
        }
        else
        {
            Vector3 lastPoint = tr.position;
            
            Sequence mySequence = DOTween.Sequence();
            
            for (int i = 0; i < p.path.Count; i++)
            {
                destination = new Vector3 (p.vectorPath[i].x, p.vectorPath[i].y, p.vectorPath[i].z);
                
                float duration = Vector3.Distance(lastPoint, destination) / moveSpeed;

                lastPoint = destination;

                if (tr.position != destination)
                {

                    mySequence.Append(
                        tr.DOLookAt(destination, 0)
                    );

                    mySequence.Append(
                        tr.DOMove(destination, duration)
                            .SetEase(Ease.Linear)
                    );
                }
            }

            mySequence.OnComplete(DestinationReached);
        }
    }
}
