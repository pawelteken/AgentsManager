using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerUI : MonoBehaviour
{
    public TMP_Text agentsNumText;
    
    int agentsNum;

    public void SpawnAgent()
    {
        
    }

    public void DestroyAgent()
    {
        
    }

    public void ResetAgents()
    {
      
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
