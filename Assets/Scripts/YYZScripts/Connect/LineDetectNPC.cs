using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDetectNPC : MonoBehaviour
{
    public List<GameObject> targetNPC = new List<GameObject>();
    public Material defaultMaterial, outlineWhite;
    public GameObject plotManager;
    public float timeGap;
    private void Start()
    {
        plotManager = GameObject.Find("PlotAnimBuilder");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && !targetNPC.Contains(collision.gameObject))
        {
            targetNPC.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && targetNPC.Contains(collision.gameObject))
        {
            targetNPC.Remove(collision.gameObject);
            if (collision.gameObject.GetComponent<SpriteRenderer>().material != defaultMaterial)
                collision.gameObject.GetComponent<SpriteRenderer>().material = defaultMaterial;
        }
    }
    private void FixedUpdate()
    {
        if (targetNPC.Count > 0)
            for (int i = 0; i < targetNPC.Count; i++)
                if (targetNPC[i].GetComponent<SpriteRenderer>().material != outlineWhite)
                    targetNPC[i].GetComponent<SpriteRenderer>().material = outlineWhite;
    }
    private void OnDestroy()
    {
        for (int i = 1; i < targetNPC.Count; i++)
        {
            if (targetNPC[i].GetComponent<SpriteRenderer>().material != defaultMaterial)
                targetNPC[i].GetComponent<SpriteRenderer>().material = defaultMaterial;
        }
    }
    public void Determine()
    {
        int goodNum = 0, badNum = 0;
        if (targetNPC.Count > 1)
        {
            for (int i = 0; i < targetNPC.Count; i++)
            {
                if (targetNPC[i].GetComponent<DetermineNPCGoodOrBad>().state == DetermineNPCGoodOrBad.NPCState.good)
                    goodNum++;
                else if (targetNPC[i].GetComponent<DetermineNPCGoodOrBad>().state == DetermineNPCGoodOrBad.NPCState.bad)
                    badNum++;
            }
            if (goodNum > badNum)
            {
                for (int i = 0; i < targetNPC.Count; i++)
                {
                    targetNPC[i].SendMessage("InvokeTransferToGood", i * timeGap, SendMessageOptions.DontRequireReceiver);
                }
            }
            else if (badNum > goodNum)
            {
                for (int i = 0; i < targetNPC.Count; i++)
                {
                    targetNPC[i].SendMessage("InvokeTransferToBad", i * timeGap, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        plotManager.GetComponent<PlotBuiltByConnect>().Judge();
        Destroy(transform.parent.gameObject);
    }
}
