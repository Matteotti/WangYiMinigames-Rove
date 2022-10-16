using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBuiltByConnect : MonoBehaviour
{
    [System.Serializable]
    public class Condition
    {
        public DetermineNPCGoodOrBad targetNPC;
        public DetermineNPCGoodOrBad.NPCState targetState;
    }
    [System.Serializable]
    public class Plot
    {
        public List<Condition> conditions;
        public float startTime;
        public string plotName;
    }
    public List<Plot> plots = new List<Plot>();
    bool JudgeCondition(List<Condition> conditions)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].targetNPC.GetComponent<DetermineNPCGoodOrBad>().state != conditions[i].targetState)
                return false;
        }
        return true;
    }
    private void Update()
    {
        for(int i = 0;i < plots.Count;i++)
        {
            Plot plot = plots[i];
            if(JudgeCondition(plot.conditions))
            {
                if(!IsInvoking(plot.plotName))
                    Invoke(plot.plotName, plot.startTime);
            }
        }
    }
}
