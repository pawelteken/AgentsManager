using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AgentsManager : MonoBehaviour
{
    public Action<int> onAgentsNumChanged;

    public GameObject agentPrefab;
    public Transform ground;
    
    List<GameObject> allAgents = new List<GameObject>();

    float planeSize = 5f;
    float groundSizeX;
    float groundSizeZ;

    void Awake()
    {
        groundSizeX = ground.lossyScale.x * planeSize;
        groundSizeZ = ground.lossyScale.z * planeSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnAgent();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnAgent(10);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            DestroyAgent();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAgents();
        }
    }

    public void SpawnAgent()
    {
        GameObject newAgent = Instantiate(agentPrefab);
        allAgents.Add(newAgent);

        newAgent.transform.position = GetRandomPoint();
        AgentController agentController = newAgent.GetComponent<AgentController>();
        agentController.Init(this);
        agentController.MoveToNewDestination();
        
        if (onAgentsNumChanged != null)
        {
            onAgentsNumChanged(allAgents.Count);
        }
    }

    public void SpawnAgent(int spawnNum)
    {
        for (int i = 0; i < spawnNum; i++)
        {
            SpawnAgent();
        }
    }

    public void DestroyAgent()
    {
        if (allAgents.Count == 0) return;
        
        GameObject destroyAgent = allAgents[allAgents.Count - 1];
        allAgents.RemoveAt(allAgents.Count - 1);
        Destroy(destroyAgent);

        if (onAgentsNumChanged != null)
        {
            onAgentsNumChanged(allAgents.Count);
        }
    }

    public void ResetAgents()
    {
        for (int i = 0; i < allAgents.Count; i++)
        {
            Destroy(allAgents[i]);
        }
        
        allAgents.Clear();
        
        if (onAgentsNumChanged != null)
        {
            onAgentsNumChanged(allAgents.Count);
        }
    }

    public Vector3 GetRandomPoint()
    {
        return new Vector3(
            Random.Range(-groundSizeX, groundSizeX),
            0f,
            Random.Range(-groundSizeZ, groundSizeZ)
        );
    }
}
