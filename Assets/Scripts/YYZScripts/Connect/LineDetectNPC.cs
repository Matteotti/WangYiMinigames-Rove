using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDetectNPC : MonoBehaviour
{
    public List<GameObject> targetNPC = new List<GameObject>();
    public Material defaultMaterial, outlineBlue, outlineYellow;
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
        {
            if (targetNPC[0].GetComponent<SpriteRenderer>().material != outlineYellow)
                targetNPC[0].GetComponent<SpriteRenderer>().material = outlineYellow;
            for (int i = 1; i < targetNPC.Count - 1; i++)
            {
                if (targetNPC.Count > 0)
                {
                    if (targetNPC[i].GetComponent<SpriteRenderer>().material != outlineBlue)
                        targetNPC[i].GetComponent<SpriteRenderer>().material = outlineBlue;
                }
            }
            if (targetNPC[targetNPC.Count - 1].GetComponent<SpriteRenderer>().material != outlineYellow)
                targetNPC[targetNPC.Count - 1].GetComponent<SpriteRenderer>().material = outlineYellow;
        }
    }
}
