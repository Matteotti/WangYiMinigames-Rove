using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBuiltByTime : MonoBehaviour
{
    //记得加注释怎么使用
    //时间线剧情：玩手机看视频->老人摔倒->连线->老人起身->放插画
    //最后一个函数没写完
    public bool isConnected;
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
        if(isConnected && !IsInvoking())
        {
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
        showPlotImage.SendMessage("ShowInOrder", SendMessageOptions.DontRequireReceiver);
    }
}
