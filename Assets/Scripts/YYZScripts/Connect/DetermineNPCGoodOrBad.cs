using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineNPCGoodOrBad : MonoBehaviour
{
    //气泡闪动效果
    public enum NPCState
    {
        good,
        bad,
        balance
    }
    public NPCState state;
    void ShowIcon(GameObject icon)
    {
        //展示图标
    }
    void TransferToGood()
    {
        Debug.Log("TRANSFER TO " + NPCState.good);
    }
    void TransferToBad()
    {
        Debug.Log("TRANSFER TO " + NPCState.bad);
    }
    void InvokeTransferToGood(float time)
    {
        Invoke(nameof(TransferToGood), time);
    }
    void InvokeTransferToBad(float time)
    {
        Invoke(nameof(TransferToBad), time);
    }
}
