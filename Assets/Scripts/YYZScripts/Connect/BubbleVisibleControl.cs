using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleVisibleControl : MonoBehaviour
{
    public RuntimeAnimatorController good, bad, balance;
    public Animator targetAnimator;
    public SpriteRenderer bubbleRenderer;
    public float showSpeed, stableTime;
    [SerializeField] private bool show;
    private void Start()
    {
        targetAnimator = GetComponent<Animator>();
        bubbleRenderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    void Update()
    {
        if(gameObject.activeSelf)
        {
            if(show)
            {
                if(bubbleRenderer.color.a < 0.9)
                    bubbleRenderer.color += new Color(0, 0, 0, showSpeed * Time.deltaTime);
                else
                {
                    bubbleRenderer.color = new Color(1, 1, 1, 1);
                    if(!IsInvoking(nameof(HideIcon)))
                    {
                        Invoke(nameof(HideIcon), stableTime);
                    }
                }
            }
            else
            {
                if (bubbleRenderer.color.a > 0.1)
                    bubbleRenderer.color -= new Color(0, 0, 0, showSpeed * Time.deltaTime);
                else
                {
                    bubbleRenderer.color = new Color(1, 1, 1, 0);
                    gameObject.SetActive(false);
                }
            }
        }
    }
    public void ShowIconAfterConnection(DetermineNPCGoodOrBad.NPCState state)
    {
        if (state == DetermineNPCGoodOrBad.NPCState.good)
            targetAnimator.runtimeAnimatorController = good;
        else if (state == DetermineNPCGoodOrBad.NPCState.bad)
            targetAnimator.runtimeAnimatorController = bad;
        bubbleRenderer.color = new Color(1, 1, 1, 0);
        show = true;
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }
    void HideIcon()
    {
        show = false;
    }
}
