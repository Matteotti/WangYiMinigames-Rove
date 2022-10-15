using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineNPCGoodOrBad : MonoBehaviour
{
    public BubbleVisibleControl NPCBubble;
    public enum NPCState
    {
        good,
        bad,
        balance
    }
    public NPCState state;
    void TransferToGood()
    {
        state = NPCState.good;
        NPCBubble.ShowIconAfterConnection(NPCState.good);
    }
    void TransferToBad()
    {
        state = NPCState.bad;
        NPCBubble.ShowIconAfterConnection(NPCState.bad);
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
