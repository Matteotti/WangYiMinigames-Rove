using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOutline : MonoBehaviour
{
    public InstantiateLine sendDetectInfoTo;
    public GameObject lastNPC;
    public Material outlineYellow, defaultMaterial;
    public float checkDistance;
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up, checkDistance);
        if (hit.collider != null && hit.collider.CompareTag("NPC"))
        {
            sendDetectInfoTo.NPCDetected = true;
            if (lastNPC != hit.collider.gameObject)
                lastNPC = hit.collider.gameObject;
            if (!sendDetectInfoTo.allowInstantiateLine && lastNPC.GetComponent<SpriteRenderer>().material != outlineYellow)
            {
                lastNPC.GetComponent<SpriteRenderer>().material = outlineYellow;
            }
        }
        else
        {
            sendDetectInfoTo.NPCDetected = false;
            if (!sendDetectInfoTo.allowInstantiateLine && lastNPC != null && lastNPC.GetComponent<SpriteRenderer>().material != defaultMaterial)
            {
                lastNPC.GetComponent<SpriteRenderer>().material = defaultMaterial;
            }
        }
    }
}
