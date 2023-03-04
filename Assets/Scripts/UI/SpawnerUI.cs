using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerUI : MonoBehaviour
{
    public AgentsManager agentsManager;
    public TMP_Text agentsNumText;
    
    int agentsNum;

    void Awake()
    {
        agentsManager.onAgentsNumChanged += AgentsNumChanged;
    }

    void OnDestroy()
    {
        agentsManager.onAgentsNumChanged -= AgentsNumChanged;
    }

    public void SpawnAgent()
    {
        agentsManager.SpawnAgent();
    }
    
    public void SpawnAgents(int spawnNum)
    {
        agentsManager.SpawnAgent(spawnNum);
    }

    public void DestroyAgent()
    {
        agentsManager.DestroyAgent();
    }

    public void ResetAgents()
    {
        agentsManager.ResetAgents();
    }

    public void AgentsNumChanged(int setAgentNum)
    {
        agentsNum = setAgentNum;
        RefreshAgentsNum();
    }

    void RefreshAgentsNum()
    {
        agentsNumText.text = agentsNum.ToString();
    }
}
