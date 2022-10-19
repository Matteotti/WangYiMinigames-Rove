using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBuiltByTime : MonoBehaviour
{
    public bool isConnected, isFirstTime;
    public GameObject lineManager, showPlotImage;
    public List<Plot> plots = new List<Plot>();
    public List<GameObject> PhoneAndVideoNPC = new List<GameObject>();
    public Animator oldMadamAnimator;
    [System.Serializable]
    public class Plot
    {
        public bool needConnectFirst;
        public float startTime;
        public string plotName;
    }
    private void Start()
    {
        for (int i = 0; i < plots.Count; i++)
        {
            if (!plots[i].needConnectFirst)
                Invoke(plots[i].plotName, plots[i].startTime);
        }
    }
    private void Update()
    {
        if(isConnected && !IsInvoking() && isFirstTime)
        {
            isFirstTime = false;
            for (int i = 0; i < plots.Count; i++)
            {
                Plot plot = plots[i];
                if (plot.needConnectFirst)
                    Invoke(plot.plotName, plot.startTime);
            }
        }
    }
    void NPCHaveFun()
    {
        for(int i = 0;i < PhoneAndVideoNPC.Count;i++)
        {
            PhoneAndVideoNPC[i].GetComponent<DetermineNPCGoodOrBad>().NPCBubble.GetComponent<BubbleVisibleControl>().ShowIconAfterConnection(DetermineNPCGoodOrBad.NPCState.plot);
        }
    }
    void OldManFall()
    {
        oldMadamAnimator.SetBool("Fall", true);
        lineManager.GetComponent<InstantiateLine>().isPlotFinished = true;
    }
    void OldManStandUp()
    {
        oldMadamAnimator.SetBool("Fall", false);
        oldMadamAnimator.SetBool("Stand", true);
    }
    void GameEndImage()
    {
        showPlotImage.SetActive(true);
        showPlotImage.SendMessage("ShowImageInOrder", SendMessageOptions.DontRequireReceiver);
    }
}
