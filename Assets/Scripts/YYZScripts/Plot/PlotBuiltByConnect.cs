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
        public bool isNew;
    }
    public List<Plot> plots = new List<Plot>();
    public List<GameObject> movedAwayNPC = new List<GameObject>();
    bool JudgeCondition(List<Condition> conditions)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].targetNPC.GetComponent<DetermineNPCGoodOrBad>().state != conditions[i].targetState)
                return false;
        }
        return true;
    }
    public void Judge()
    {
        for (int i = 0; i < plots.Count; i++)
        {
            Plot plot = plots[i];
            if (plot.isNew && JudgeCondition(plot.conditions))
            {
                Invoke(plot.plotName, plot.startTime);
                plot.isNew = false;
            }
        }
    }
    void TriggerNPCMoveAway()
    {
        for(int i = 0; i < movedAwayNPC.Count; i++)
        {
            movedAwayNPC[i].GetComponent<NPCMoveAway>().MoveAwayTrigger();
        }
    }
}
